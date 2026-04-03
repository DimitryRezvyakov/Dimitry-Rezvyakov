using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example.Drinks
{
    public class Americano : Beverage
    {
        public override string GetDescription()
        {
            return "Американо";
        }

        public override decimal GetCost()
        {
            return 2.00m;
        }
    }
}
