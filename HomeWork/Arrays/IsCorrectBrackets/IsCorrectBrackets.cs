using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Arrays.IsCorrectBrackets
{
    internal class IsCorrectBrackets
    {
        public static (bool, int) IsCorrectBracketsTask(string s)
        {
            int counter = 0;
            int max = -1;
            foreach (char c in s)
            {
                if (c == '(')
                    counter++;
                else if (c == ')')
                    counter--;
                max = Math.Max(max, counter);
            }
            if (counter == 0)
                return (true, max);
            return (false, max);
        }
    }
}
