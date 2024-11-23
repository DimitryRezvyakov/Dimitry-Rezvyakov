using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Strings.IsPalindrom
{
    internal class IsPalindrom
    {
        public static bool IsPalindromTask(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (!str[i].Equals(str[str.Length - i - 1]))
                    return false;
            }
            return true;
        }
    }
}
