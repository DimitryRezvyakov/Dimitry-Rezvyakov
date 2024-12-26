using Debtors.GetData;
using Debtors.StringValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetNamesData
{
    internal class GetNamesService(IStringValidator stringValidator) : IGetNames
    {

        static int MaxLength = 100;

        public Persons GetNames()
        {
            var names = new List<string>();

            StartSession();
            MainProcess(ref names);

            return new Persons(names);
        }

        private void StartSession()
        {
            Console.WriteLine("Введите имена, пустая строка будет значить, что ввод закончен.");
        }

        private List<string> MainProcess(ref List<string> data)
        {
            
            string inputName = stringValidator.GetValidString(StringValidator.AlphaString, "Введите имя");

            while (data.Count < MaxLength)
            {
                if (data.Contains(inputName))
                {
                    Console.WriteLine("Это имя уже было введено.");
                    inputName = stringValidator.GetValidString(StringValidator.AlphaString, "Введите имя");
                    continue;
                }
                data.Add(inputName);
                inputName = stringValidator.GetValidString(StringValidator.AlphaString, "Введите имя", true);

                if (inputName == "")
                    break;
            }
            return data;
        }
    }
}