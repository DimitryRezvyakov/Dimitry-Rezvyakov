using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Strings.TextCapitalize
{
    internal class TextCapitalize
    {
        public static string TextCapitalizeTask(string str)
        {
            string[] words = str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]).ToString() + words[i].Substring(1);
            }
            return string.Join(' ', words);
        }
    }
}
