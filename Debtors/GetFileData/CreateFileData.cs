using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetData
{
    internal class CreateFileData : ICreateFileData
    {
        public FileData MCreateFileData()
        {
                StartSession();

                string name = Console.ReadLine();
                DateTime creationDate;

                if (!DateTime.TryParse(Console.ReadLine(), out creationDate))
                    throw new FormatException("Неверный формат");

                string path = Console.ReadLine();
                string fileName = Console.ReadLine();

                if (new string[] { name, path, fileName }.All(elem => !string.IsNullOrEmpty(elem)))
                    return new FileData(name, creationDate, path, fileName);

                throw new FormatException("Неверные значения");
        }

        public static void StartSession()
        {
            Console.WriteLine("Введите Имя, Дату, Путь(без названия файлa), Имя Файла - каждое с новой строки.");
        }
    }
}
