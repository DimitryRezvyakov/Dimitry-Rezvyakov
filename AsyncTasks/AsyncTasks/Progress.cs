using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTasks
{
    public interface IProgress
    {
        public void Log(long total, long current);
    }

    public class Progress : IProgress
    {
        public void Log(long total, long current)
        {
            Console.WriteLine(current * 100 / total);
        }
    }

    public class Reader
    {
        private readonly string _path;
        private IProgress _tracker;

        public Reader(string path, IProgress tracker)
        {
            _path = path;
            _tracker = tracker;
        }

        public async Task<string> DownloadFile()
        {
            var fileInfo = new FileInfo(_path);


            var total = fileInfo.Length;
            var current = 0;
            var buffer = new char[4096];

            var res = new StringBuilder();

            using (var stream = new StreamReader(_path))
            {
                while (true)
                {
                    var bytesReaded = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesReaded == 0) break;

                    current += bytesReaded;

                    res.Append(buffer, 0, bytesReaded);

                    _tracker.Log(total, current);
                }

                return res.ToString();
            }
        }
    }
}