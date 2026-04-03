using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example.Drinks
{
    public class Cappuccino : Beverage
    {
        public override string GetDescription()
        {
            return "Капучино";
        }

        public override decimal GetCost()
        {
            return 3.00m;
        }
    }
}
