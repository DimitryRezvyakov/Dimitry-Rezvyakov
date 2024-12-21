using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debtors
{
    internal static class Validator
    {
        public static bool IsValidString(string value)
        {
            if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                return true;
            throw new ArgumentException($"{value} is null or empty");
        }

        public static bool IsValidStrings(string[] value)
        {
            if (value.All(x => IsValidString(x)))
                return true;
            throw new ArgumentException($"At least one string in {value} is null or empty");
        }

        public static bool IsDigitString(string value)
        {
            if (int.TryParse(value, out var digit))
                return true;
            throw new ArgumentException($"{value} is not digit.");
        }

        public static bool IsDigitStrigs(string[] value)
        {
            if (value.All(x => IsDigitString(x)))
                return true;
            throw new ArgumentException($"At least one string in {value} is not digit");
        }

        public static bool IsExpectedType(Type type, object obj)
        {
            return type == obj.GetType();
        }
    }
}
