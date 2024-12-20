using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetData
{
    internal class FileData(string name, DateTime creationDate, string path, string fileName) : IFileData
    {
        public string Name { get; } = name;
        public DateTime CreationDate { get; } = creationDate;
        public string Path { get; } = path;
        public string FileName { get; } = fileName;
    }
}
