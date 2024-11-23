using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Arrays.ReverseArray
{
    internal class ReverseArray
    {
        public static int[] ReverseArrayTask(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                (array[i], array[array.Length - i - 1]) = (array[array.Length - i - 1], array[i]);
            }
            return array;
        }
    }
}
