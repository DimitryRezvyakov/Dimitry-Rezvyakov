using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetNames_
{
    internal class GetNames : IGetNames
    {

        static int MaxLength = 100;

        //returns a new Person экземпляр
        public Persons MGetNames()
        {
            var names = new List<string>();

            StartSession();
            MainProcess(ref names);

            return new Persons(names);
        }

        //hint for user
        public void StartSession()
        {
            Console.WriteLine("Введите имена, пустая строка будет значить, что ввод закончен.");
        }

        //read Console and write Names in Person.Names
        public List<string> MainProcess(ref List<string> data)
        {
            
            string inputName = Console.ReadLine();

            while (Validator.IsValidString(inputName) && data.Count < MaxLength)
            {
                if (data.Contains(inputName))
                {
                    Console.WriteLine("Это имя уже было введено.");
                    inputName = Console.ReadLine();
                    continue;
                }
                data.Add(inputName);
                inputName = Console.ReadLine();
            }
            return data;
        }
    }
}