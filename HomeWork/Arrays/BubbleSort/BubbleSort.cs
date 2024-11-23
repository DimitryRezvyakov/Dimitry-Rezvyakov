using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Arrays.BubbleSort
{
    internal class BubbleSort
    {
        public static void BubbleSortTask(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        isSorted = false;
                    }
                }
                if (isSorted) break;
            }
        }
    }
}
