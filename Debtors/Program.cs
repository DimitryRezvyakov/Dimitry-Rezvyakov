using Debtors.GetData;
using Debtors.GetPartyData_;
using System;
using Microsoft.Extensions.DependencyInjection;
using Debtors.GetNames_;
using Debtors.Calculations;
using Debtors.OutputData;
namespace Debtors
{
    public class MainProgram
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();

            services.AddTransient<IGetPartyData, GetPartyData>();
            services.AddTransient<ICreateFileData, CreateFileData>();
            services.AddTransient<IGetNames, GetNames>();
            services.AddTransient<ICalculateResult, CalculateResult>();
            services.AddTransient<IOutData, OutData>();

            var serviceProvider = services.BuildServiceProvider();

            var fileData = serviceProvider.GetService<ICreateFileData>().MCreateFileData();

            var names = serviceProvider.GetService<IGetNames>()?.MGetNames();

            var file = serviceProvider.GetService<IOutData>()?.CreateFile(fileData);

            var barsDataStorage = new BarsDataStorage();

            serviceProvider.GetService<IOutData>()?.WriteMainInformationToFile(file);

            while (true)
            {
                var partyData = serviceProvider.GetService<IGetPartyData>()?.GetPartyD();
                serviceProvider.GetService<IGetPartyData>()?.GetDebtors(names, partyData);
                barsDataStorage.AddBar(partyData);

                serviceProvider.GetService<IOutData>()?.WriteAboutBarsToFile(file, partyData);

                Console.WriteLine("Добавить новое заведение? (+ Да, - Нет)");

                if (Console.ReadLine() == "-")
                    break;
            }
            serviceProvider.GetService<ICalculateResult>()?.GetCalculatedResult(barsDataStorage);

            serviceProvider.GetService<IOutData>()?.WriteCalculatedInformationToFile(file, barsDataStorage);

            serviceProvider.GetService<IOutData>()?.WriteResultToConsole(file);
            //TODO DataBase, OutData
        }
    }
}