using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetData
{
    internal interface IFileData
    {
        string Name { get; }
        DateTime CreationDate { get; }
        string Path { get; }
        string FileName { get; }

    }
}
