using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetPartyData_
{
    internal class PartyData(string barName, int totalCheck, string Payer)
    {
        public PartyData(PartyData data) : this(data.BarName, data.TotalCheck, data.Payer)
        {
            this.Names = data.Names;
        }

        public Dictionary<string, int> Names = new Dictionary<string, int>();
        public string BarName = barName;
        public int TotalCheck = totalCheck;
        public string Payer = Payer;
    }
}
