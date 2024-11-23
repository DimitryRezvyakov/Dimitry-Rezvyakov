using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Strings.GetNumbersFromString
{
    internal class GetNumbersFromString
    {
        public static string GetNumbersFromStringTask(string str)
        {
            int b;
            string result = "";
            foreach (char chr in str)
            {
                if (int.TryParse(chr.ToString(), out b))
                    result += chr.ToString();
            }
            return result;
        }
    }
}
