using Debtors.Calculations;
using Debtors.GetData;
using Debtors.GetPartyData_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.OutputData
{
    internal interface IOutData
    {
        FileOut CreateFile(FileData fileData);
        void WriteMainInformationToFile(FileOut fileOut);

        void WriteAboutBarsToFile(FileOut fileOut, PartyData partyData);

        void WriteCalculatedInformationToFile(FileOut fileOut, BarsDataStorage barsDataStorage);

        void WriteResultToConsole(FileOut fileOut);
    }
}
