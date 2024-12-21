using Debtors.GetNames_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors.GetPartyData_
{
    internal class GetPartyData : IGetPartyData
    {
        //Gives information to user and create new PartyData class
        public PartyData GetPartyD()
        {
            StartSession();
            string barName = Console.ReadLine();
            string totalCheck = Console.ReadLine();
            string payer = Console.ReadLine();

            if (Validator.IsValidStrings(new string[] {barName, totalCheck, payer}) && Validator.IsDigitString(totalCheck))
                return new PartyData(barName, int.Parse(totalCheck), payer);

            throw new Exception();

        }

        //Fill the PartyData.Names dictionary with values
        public void GetDebtors(Persons persons, PartyData partyData)
        {
            bool isRunning = true;
            var accumulator = 0;

            Console.WriteLine("Для каждого человека введити сумму рублей, которую он потратил.");
            foreach(string name in persons.Names)
            {
                if (name == partyData.Payer)
                    continue;

                Console.WriteLine(name);
                var number = GetNumber();

                if (number + accumulator > partyData.TotalCheck)
                    throw new Exception("Итоговая сумма чека не совпадает с текущей");

                partyData.Names[name] = number;
            }

            Console.WriteLine("Добавить друзей?(+ Да, - Нет)");

            string answer = Console.ReadLine();

            Validator.IsValidString(answer);

            if (answer == "+")
            {
                AddDebtors(persons, partyData);
            }
        }

        // Adding new Debtors
        public static void AddDebtors(Persons person, PartyData partyData)
        {
            string answer = "+";
            while (answer == "+")
            {
                string name = Console.ReadLine();
                string check = Console.ReadLine();
                Validator.IsValidStrings(new string[] {name, check});
                Validator.IsDigitString(check);

                if (person.Names.Contains(name))
                {
                    Console.WriteLine("Имя уже было добавлено.");
                    continue;
                }

                person.Names.Add(name);
                partyData.Names[name] = int.Parse(check);
                Console.WriteLine("Добавить друзей?(+ Да, - Нет)");
                answer = Console.ReadLine();
            }
        }
        //Hint for user
        static void StartSession()
        {
            Console.WriteLine("Введите название бара, общий чек, имя человека, оплатившего чек - каждое на новой строке.");
        }

        //Works until the user wouldn`t type a valid number
        static int GetNumber()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
                continue;
            return result;
        }
    }
}
