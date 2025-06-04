using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTasks
{
    class Program
    {

        public static void Main()
        {
            var path = @"C:\Users\Dima\OneDrive\Desktop";

            var reader = new Reader(path, new Progress());

            reader.DownloadFile();
        }
    }
}
