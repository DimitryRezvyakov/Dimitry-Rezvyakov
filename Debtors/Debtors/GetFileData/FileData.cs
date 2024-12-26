using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetData
{
    internal readonly struct FileData(string name, DateTime creationDate, string path, string fileName)
    {
        public readonly string Name { get; } = name;
        public readonly DateTime CreationDate { get; } = creationDate;
        public readonly string Path { get; } = path;
        public readonly string FileName { get; } = fileName;
    }
}
