using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example.Drinks
{
    public class Espresso : Beverage
    {
        public override string GetDescription()
        {
            return "Эспрессо";
        }

        public override decimal GetCost()
        {
            return 2.50m;
        }
    }
}
