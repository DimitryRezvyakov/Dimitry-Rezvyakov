using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Debtors.StringValidation
{
    internal class StringValidator : IStringValidator
    {
        public static string AlphaString = @"^[a-zA-Zа-яА-Я0-9_-]+(\s+[a-zA-Zа-яА-Я0-9_-]+)*$";
        public static string DigitString = @"^\d+([.,]\d+)?$";
        public static string ApplyString = @"^[+-]$";
        public static string DateString = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$";
        public static string FilePathString = @"^[a-zA-Zа-яА-Я]:\\(?:[\wа-яА-Я]+\\)*[\wа-яА-Я]+$|^([a-zA-Z0-9а-яА-Я-_]+\/)*[a-zA-Z0-9а-яА-Я-_]+$";
        public static string FileTxtString = @"^[a-zA-Zа-яА-Я0-9_-]+(?:[a-zA-Zа-яА-Я0-9_-]*\.[a-zA-Zа-яА-Я0-9_-]+)*\.txt$";

        public string GetValidString(string pattern, string argument = "", bool returnEmptyString = false)
        {
            string result = Console.ReadLine();
            while (true)
            {

                if (Regex.IsMatch(result, pattern))
                    break;

                if (returnEmptyString && result == "")
                    return result;

                Console.WriteLine($"Неправильное значение." + $" {argument}");
                result = Console.ReadLine();
            }
            return result;
        }
    }
}
