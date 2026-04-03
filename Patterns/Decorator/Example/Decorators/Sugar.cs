using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example.Decorators
{
    public class Sugar : BeverageDecorator
    {
        public Sugar(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return $"{_beverage.GetDescription()} + сахар";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.20m;
        }
    }
}
