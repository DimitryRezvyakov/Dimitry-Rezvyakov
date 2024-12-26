using Debtors.GetData;
using Debtors.GetPartyData;
using System;
using Microsoft.Extensions.DependencyInjection;
using Debtors.GetNamesData;
using Debtors.Calculations;
using Debtors.OutputData;
using Debtors.DataBase;
using System.ComponentModel.DataAnnotations;
using Debtors.StringValidation;
namespace Debtors
{
    public class MainProgram
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();

            services.AddSingleton<IStringValidator, StringValidator>();
            services.AddTransient<IGetPartyData, GetPartyDataService>();
            services.AddTransient<ICreateFileData, CreateFileDataService>();
            services.AddTransient<IGetNames, GetNamesService>();
            services.AddTransient<ICalculateResult, CalculateResultService>();
            services.AddTransient<IOutData, OutDataService>();
            services.AddTransient<IDataContext, DataContext>();

            var serviceProvider = services.BuildServiceProvider();

            var fileData = serviceProvider.GetService<ICreateFileData>().CreateFileData();

            var names = serviceProvider.GetService<IGetNames>()?.GetNames();

            var file = serviceProvider.GetService<IOutData>()?.CreateFile(fileData);

            var barsDataStorage = new BarsDataStorage();

            serviceProvider.GetService<IOutData>()?.WriteMainInformationToFile(file);

            while (true)
            {
                var partyData = serviceProvider.GetService<IGetPartyData>()?.GetPartyData();
                serviceProvider.GetService<IGetPartyData>()?.GetDebtors(names, partyData);
                barsDataStorage.AddBar(partyData);

                serviceProvider.GetService<IOutData>()?.WriteAboutBarsToFile(file, partyData);

                Console.WriteLine("Добавить новое заведение? (+ Да, - Нет)");

                if (serviceProvider.GetService<IStringValidator>()?.GetValidString(StringValidator.ApplyString) == "-")
                    break;
            }

            serviceProvider.GetService<IDataContext>()?.WriteData(names);

            serviceProvider.GetService<ICalculateResult>()?.GetCalculatedResult(barsDataStorage);

            serviceProvider.GetService<IOutData>()?.WriteCalculatedInformationToFile(file, barsDataStorage);

            serviceProvider.GetService<IOutData>()?.WriteResultToConsole(file);
        }
    }
}