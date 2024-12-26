using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.Calculations
{
    internal class CalculateResultService : ICalculateResult
    {
        public void GetCalculatedResult(BarsDataStorage barsData)
        {
            var dictionary = barsData.BarsData;
            foreach (var externalKey in dictionary.Keys)
            {
                foreach (var internalKey in dictionary[externalKey].Keys)
                {
                    if (dictionary.ContainsKey(internalKey) && dictionary[internalKey].ContainsKey(externalKey))
                    {
                        var firstNameValue = dictionary[externalKey][internalKey];
                        var secondNameValue = dictionary[internalKey][externalKey];

                        if (dictionary[externalKey][internalKey] < dictionary[internalKey][externalKey])
                        {
                            dictionary[internalKey][externalKey] -= dictionary[externalKey][internalKey];
                            dictionary[externalKey].Remove(internalKey);
                        }

                        else if (dictionary[externalKey][internalKey] > secondNameValue)
                        {
                            dictionary[externalKey][internalKey] -= dictionary[internalKey][externalKey];
                            dictionary[internalKey].Remove(externalKey);
                        }

                        else
                        {
                            dictionary[externalKey].Remove(internalKey);
                            dictionary[internalKey].Remove(externalKey);
                        }
                    }
                }
            }
        }

    }
}
