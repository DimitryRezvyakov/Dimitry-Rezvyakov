using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Arrays.ThrowDice
{
    internal class ThrowDice
    {

        public static void ThrowDiceTask()
        {
            Random rnd = new Random();
            int side = rnd.Next(1, 7);
            int[,] dice = new int[3, 3];
            for (int i = 0; i < dice.GetLength(0); i++)
            {
                for (int j = 0; j < dice.GetLength(1); j++)
                {
                    switch (side)
                    {
                        case 1:
                            dice[i, j] = Convert.ToInt32(i == j && j == 1);
                            break;
                        case 2:
                            dice[i, j] = Convert.ToInt32(i == 1 && (j == 0 || j == 2));
                            break;
                        case 3:
                            dice[i, j] = Convert.ToInt32(i == 1);
                            break;
                        case 4:
                            dice[i, j] = Convert.ToInt32((i == 0 || i == 2) && (j == 0 || j == 2));
                            break;
                        case 5:
                            dice[i, j] = Convert.ToInt32(i == j || i + j == 2);
                            break;
                        case 6:
                            dice[i, j] = Convert.ToInt32(j == 0 || j == 2);
                            break;
                    }
                }
            }
            PrintTwoDimensArr(dice);
        }

        static void PrintTwoDimensArr(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == array.GetLength(1) - 1) Console.WriteLine(array[i, j]);
                    else Console.Write($"{array[i, j]} ");
                }
            }
        }
    }
}
