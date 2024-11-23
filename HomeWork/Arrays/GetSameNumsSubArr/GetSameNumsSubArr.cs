using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Arrays.GetSameNumsSubArr
{
    internal class GetSameNumsSubArr
    {
        public static int[] GetSameNumbersSubArrTask(int[] array)
        {
            if (array.Length <= 1)
                return array;

            int start = 0;
            int end = 1;
            (int startIndex, int endIndex) max = (0, 0);
            while (end < array.Length)
            {
                if (array[end] != array[start])
                {
                    start = end;
                    end = start + 1;
                }

                else
                {
                    end += 1;
                    if (max.endIndex - max.startIndex < end - start)
                        max = (start, end);
                }
            }
            return array[max.startIndex..max.endIndex];
        }
    }
}