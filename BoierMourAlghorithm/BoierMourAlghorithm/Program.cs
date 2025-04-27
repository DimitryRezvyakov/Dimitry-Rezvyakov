using BierMourAlghorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BoierMourAlghorithm
{
    public class Program
    {
        public static void Main()
        {
            string[] filePaths = Directory
                .GetFiles(
                "C:\\Users\\Dima\\source\\repos\\BoierMourAlghorithm\\BoierMourAlghorithm\\TestFiles"
                );

            foreach (var filePath in filePaths)
            {
                Tester.TestBoyerMoore(
                    File.ReadAllText(filePath),
                    Path.GetFileNameWithoutExtension(filePath).Split("_").Last()
                    );
            }
        }

        public static int CountUniqueCharacters(string text)
        {
            HashSet<char> uniqueChars = new HashSet<char>();

            foreach (char c in text)
            {
                if (!Char.IsWhiteSpace(c)) // если нужно игнорировать пробелы
                    uniqueChars.Add(c);
            }

            return uniqueChars.Count;
        }
    }
    public class Tester
    {
        public static void TestBoyerMoore(string text, string pattern)
        {
            Console.WriteLine($"\nШаблон: {pattern}");
            Console.WriteLine($"Длина паттерна {pattern.Length}");
            Console.WriteLine($"Количество уникальных символов алфавита {Program.CountUniqueCharacters(text)}");
            Console.WriteLine($"Длина строки: {text.Length}");
            var searcher = new BoyerMoore();
            var result = searcher.Search(text, pattern);

            Console.WriteLine($"Индекс последнего вхождения: {result.Last().ToString()}");
            if (result.Count == 0)
            {
                Console.WriteLine("Вхождений не найдено.");
            }
            else
                Console.WriteLine($"Найдено вхождений {result.Count}");

            Console.WriteLine($"Количество операций сравнения: {searcher.OperationsCount}");
        }
    }
}