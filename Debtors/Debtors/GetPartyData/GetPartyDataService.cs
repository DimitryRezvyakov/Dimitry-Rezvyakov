using Debtors.GetNamesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Debtors.StringValidation;

namespace Debtors.GetPartyData
{
    internal class GetPartyDataService(IStringValidator stringValidator) : IGetPartyData
    {
        public PartyData GetPartyData()
        {
            StartSession();
            string barName = stringValidator.GetValidString(StringValidator.AlphaString, "Введите название бара.");
            string totalCheck = stringValidator.GetValidString(StringValidator.DigitString, "Введите общую сумму чека.");
            string payer = stringValidator.GetValidString(StringValidator.AlphaString, "Введите человека, который оплатил счет.");
            return new PartyData(barName, double.Parse(totalCheck, CultureInfo.InvariantCulture), payer);
        }

        //Fill the PartyData.Names dictionary with values
        public void GetDebtors(Persons persons, PartyData partyData)
        {
            var accumulator = 0;

            Console.WriteLine("Для каждого человека введити сумму рублей, которую он потратил.");
            foreach(string name in persons.Names)
            {
                if (name == partyData.Payer)
                    continue;

                Console.WriteLine(name);
                var number = double.Parse(stringValidator.GetValidString(StringValidator.DigitString, $"Введите сумму которую пропил {name}"), CultureInfo.InvariantCulture);

                if (number + accumulator > partyData.TotalCheck)
                    throw new Exception("Итоговая сумма чека не совпадает с текущей");

                partyData.Names[name] = number;
            }

            Console.WriteLine("Добавить друзей?(+ Да, - Нет)");

            string answer = stringValidator.GetValidString(StringValidator.ApplyString, "+ |||| -");

            if (answer == "+")
            {
                AddDebtors(persons, partyData);
            }
        }

        // Adding new Debtors
        private void AddDebtors(Persons person, PartyData partyData)
        {
            string answer = "+";
            while (answer == "+")
            {
                string name = stringValidator.GetValidString(StringValidator.AlphaString, "Введите имя");

                if (person.Names.Contains(name))
                {
                    Console.WriteLine("Имя уже было добавлено.");
                    continue;
                }

                string check = stringValidator.GetValidString(StringValidator.DigitString, "Введите сумму");

                person.Names.Add(name);
                partyData.Names[name] = double.Parse(check, CultureInfo.InvariantCulture);
                Console.WriteLine("Добавить друзей?(+ Да, - Нет)");
                answer = stringValidator.GetValidString(StringValidator.AlphaString, "+ |||| -");
            }
        }
        //Hint for user
        private void StartSession()
        {
            Console.WriteLine("Введите название бара, общий чек, имя человека, оплатившего чек - каждое на новой строке.");
        }
    }
}
