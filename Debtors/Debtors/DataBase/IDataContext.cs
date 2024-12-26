using Debtors.GetNamesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.DataBase
{
    internal interface IDataContext
    {
        void WriteData(Persons persons);
    }
}
