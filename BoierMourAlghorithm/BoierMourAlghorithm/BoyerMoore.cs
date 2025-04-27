using System;
using System.Collections.Generic;
using System.Text;

namespace BierMourAlghorithm
{


        public class BoyerMoore
        {
            public int OperationsCount { get; private set; }

            public List<int> Search(string text, string pattern)
            {
                int n = pattern.Length;
                int m = text.Length;
                var positions = new List<int>();

                int[] bpos = new int[n + 1];
                int[] goodSuffixShift = new int[n + 1];
                var badCharTable = BuildBadCharTable(pattern);

                PreprocessStrongSuffix(goodSuffixShift, bpos, pattern, n);
                PreprocessCase2(goodSuffixShift, bpos, pattern, n);

                int s = 0;
                while (s <= m - n)
                {
                    int j = n - 1;

                    while (j >= 0 && pattern[j] == text[s + j])
                    {
                        OperationsCount++;   // <----- для отладки
                        j--;
                    }

                    OperationsCount += j >= 0 ? 1 : 0;

                    if (j < 0)
                    {
                        positions.Add(s);
                        s += goodSuffixShift[0];
                    }
                    else
                    {
                        int badCharShift = Math.Max(1, j - badCharTable.GetValueOrDefault(text[s + j], -1));
                        s += Math.Max(badCharShift, goodSuffixShift[j + 1]);
                    }
                }
                return positions;
            }

            public static void PreprocessStrongSuffix(int[] shift, int[] bpos,
                                                     string pat, int m)
            {
                int i = m, j = m + 1;
                bpos[i] = j;

                while (i > 0)
                {
                    
                    while (j <= m && pat[i - 1] != pat[j - 1])
                    {
                        if (shift[j] == 0)
                            shift[j] = j - i;

                        j = bpos[j];
                    }
                    i--; j--;
                    bpos[i] = j;
                }
            }

            public static void PreprocessCase2(int[] shift, int[] bpos,
                                              string pat, int m)
            {
                int j = bpos[0];
                for (int i = 0; i <= m; i++)
                {
                    if (shift[i] == 0)
                        shift[i] = j;

                    if (i == j)
                        j = bpos[j];
                }
            }

            private static Dictionary<char, int> BuildBadCharTable(string pattern)
            {
                var table = new Dictionary<char, int>();
                for (int i = 0; i < pattern.Length - 1; i++)
                    table[pattern[i]] = i;
                return table;
            }
        }
    }

/*
 m - длина строки
 n - длинна паттерна
 В худшем случае О(m * n)
 В лучшем (m / n)
 Средний случай близок к лучшему.
 Многое зависит от количества уникальных символов как в алфавите(строке), так и в паттерне:
 чем больше уникальных символов в паттерне - тем меньше операций сравнения понадобиться,
 также чем больше уникальных символов в алфавите(строке) - тем меньше операций сравнения понадобиться.
 */