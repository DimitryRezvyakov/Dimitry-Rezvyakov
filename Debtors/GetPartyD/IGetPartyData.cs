using Debtors.GetNames_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetPartyData_
{
    internal interface IGetPartyData
    {
        PartyData GetPartyD();
        void GetDebtors(Persons persons, PartyData partyData);
    }
}
