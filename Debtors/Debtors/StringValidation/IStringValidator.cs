using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.StringValidation
{
    internal interface IStringValidator
    {
        string GetValidString(string pattern, string argument = "", bool returnEmptyString=false);
    }
}
