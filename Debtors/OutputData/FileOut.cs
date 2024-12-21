using Debtors.GetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.OutputData
{
    internal class FileOut(string path, FileData fileData)
    {
        public string path = path;
        public FileData fileData = fileData;
    }
}
