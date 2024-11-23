using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Arrays.BinarSearch
{
    internal class BinarSearch
    {

        public static int BinarSearchTask(int[] sortedArray, int point)
        {
            int start = -1;
            int end = sortedArray.Length + 1;
            int marker = sortedArray.Length / 2;
            while (end - start > 1)
            {
                if (sortedArray[marker] == point) return marker;
                else if (sortedArray[marker] < point) start = marker;
                else end = marker;
                marker = (end + start) / 2;
            }
            Console.WriteLine("Элемент не найден");
            return -1;
        }
    }
}
