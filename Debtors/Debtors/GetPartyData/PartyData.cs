using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetPartyData
{
    internal class PartyData(string barName, double totalCheck, string Payer)
    {
        public Dictionary<string, double> Names = new Dictionary<string, double>();
        public string BarName = barName;
        public double TotalCheck = totalCheck;
        public string Payer = Payer;
    }
}
