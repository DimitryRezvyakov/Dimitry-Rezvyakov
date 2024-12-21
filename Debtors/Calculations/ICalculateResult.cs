using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.Calculations
{
    internal interface ICalculateResult
    {
        void GetCalculatedResult(BarsDataStorage value);
    }
}
