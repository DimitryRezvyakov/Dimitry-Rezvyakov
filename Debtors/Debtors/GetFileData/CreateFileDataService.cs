using Debtors.StringValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetData
{
    internal class CreateFileDataService(IStringValidator stringValidator) : ICreateFileData
    {
        public FileData CreateFileData()
        {
                StartSession();

                string name = stringValidator.GetValidString(StringValidator.AlphaString, "Введите заголовок");
                DateTime creationDate = DateTime.Parse(stringValidator.GetValidString(StringValidator.DateString, "Введите время"));
                string path = stringValidator.GetValidString(StringValidator.FilePathString, "Введите путь, куда сохранить файл");
                string fileName = stringValidator.GetValidString(StringValidator.FileTxtString, "Введите название файла с расширением .txt");

                return new FileData(name, creationDate, path, fileName);
        }

        private static void StartSession()
        {
            Console.WriteLine("Введите Имя, Дату, Путь(без названия файлa), Имя Файла(с расширением .txt) - каждое с новой строки.");
        }
    }
}
