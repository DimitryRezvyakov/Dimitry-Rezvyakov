using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HomeWork.Strings.isAnnagram
{
    internal class IsAnnagram
    {
        public static bool IsAnnagramTask(string firstStr, string secondStr)
        {
            var chars = new Dictionary<char, int>();

            if (firstStr.Length != secondStr.Length) return false;

            for (int i = 0; i < firstStr.Length; i++)
            {
                if (!chars.TryAdd(firstStr[i], 1))
                    chars[firstStr[i]] += 1;

                if (!chars.TryAdd(secondStr[i], -1))
                    chars[secondStr[i]] -= 1;
            }

            foreach (int value in chars.Values)
                if (value != 0) return false;

            return true;
        }
    }
}
