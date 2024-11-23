using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HomeWork.Strings.LongestUniqueSubstring
{
    internal class LongestUniqueSubstring
    {
        public static string LongestUniqueSubStringTask(string str)
        {
            str = str + "_";
            if (str.Length <= 0) return str;
            (int l, int r) window = (0, 1);
            (int start, int end) max = (0, 1);

            while (window.r < str.Length)
            {
                if (new HashSet<char>(str[window.l..window.r]).Count == window.r - window.l)
                {
                    max = (window.l, window.r);
                    window = (window.l, window.r + 1);
                }

                else window = (window.l + 1, window.r + 1);
            }

            return str[max.start..max.end];
        }
    }
}