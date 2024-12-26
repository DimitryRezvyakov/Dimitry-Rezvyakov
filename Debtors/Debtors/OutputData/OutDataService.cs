using Debtors.Calculations;
using Debtors.GetData;
using Debtors.GetPartyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.OutputData
{
    internal class OutDataService : IOutData
    {
        public FileOut CreateFile(FileData fileData)
        {
            var path = fileData.Path + "/" + fileData.FileName;

            using (new FileStream(path, FileMode.Append));

            return new FileOut(path, fileData);
        }

        public void WriteAboutBarsToFile(FileOut fileOut, PartyData partyData)
        {
            using (var writer = new StreamWriter(fileOut.path, true))
            {
                writer.WriteLine("===" + partyData.BarName + "===");
                writer.WriteLine("Общий счет: " + partyData.TotalCheck);
                writer.WriteLine("Кто закрыл: " + partyData.Payer);



                int numerator = 1;

                foreach(string name in partyData.Names.Keys)
                {
                    writer.WriteLine($"{numerator}. {name}: {partyData.Names[name]}");
                    numerator++;
                }


                writer.WriteLine("==================================");
                writer.WriteLine();
                writer.WriteLine();
            }

        }

        public void WriteCalculatedInformationToFile(FileOut fileOut, BarsDataStorage barsDataStorage)
        {
            using (var writer = new StreamWriter(fileOut.path, true))
            {
                foreach (var externalName in barsDataStorage.BarsData.Keys)
                {
                    foreach (var internalName in barsDataStorage.BarsData[externalName].Keys)
                    {
                        writer.WriteLine($"{internalName} => {barsDataStorage.BarsData[externalName][internalName]} => {externalName}");
                    }
                }
            }
        }

        public void WriteMainInformationToFile(FileOut fileOut)
        {
            using (var writer = new StreamWriter(fileOut.path, true))
            {
                writer.WriteLine("===" + fileOut.fileData.Name + "===");
                writer.WriteLine(fileOut.fileData.CreationDate.ToString());

                writer.WriteLine();
                writer.WriteLine();
            }
        }

        public void WriteResultToConsole(FileOut fileOut)
        {
            using (var file = new FileStream(fileOut.path, FileMode.Open))
            {
                using (var streamReader = new StreamReader(file))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
        }
    }
}
