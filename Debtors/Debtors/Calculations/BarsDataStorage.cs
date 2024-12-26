using Debtors.GetPartyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.Calculations
{
    internal class BarsDataStorage
    {
        public Dictionary<string, Dictionary<string, double>> BarsData = new Dictionary<string, Dictionary<string, double>>();

        public void AddBar(PartyData partyData)
        {
            if (BarsData.ContainsKey(partyData.Payer))
            {
                var currentDict = BarsData[partyData.Payer];
                foreach (string name in partyData.Names.Keys)
                {
                    if (!currentDict.ContainsKey(name))
                        currentDict[name] = partyData.Names[name];

                    else
                        currentDict[name] += partyData.Names[name];
                }
            }

            else
                BarsData[partyData.Payer] = new Dictionary<string, double>(partyData.Names);
        }
    }
}
