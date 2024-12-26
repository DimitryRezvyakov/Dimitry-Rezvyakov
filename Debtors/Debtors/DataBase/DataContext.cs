using Debtors.GetNamesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.DataBase
{
    internal class DataContext : IDataContext
    {
        public void WriteData(Persons persons)
        {
            var dataNames = new HashSet<string>();
            var inputNames = new HashSet<string>(persons.Names);

            using (var stream = new StreamReader("C:\\Users\\DNS\\source\\repos\\Debtors\\Debtors\\DataBase\\data.txt"))
            {

                var line = stream.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    dataNames.Add(line);
                    line = stream.ReadLine();
                }
            }

            using (var stream = new StreamWriter("C:\\Users\\DNS\\source\\repos\\Debtors\\Debtors\\DataBase\\data.txt", true))
            {
                inputNames.ExceptWith(dataNames);
                foreach (string name in inputNames)
                {
                    stream.WriteLine(name);
                }
            }
        }
    }
}
