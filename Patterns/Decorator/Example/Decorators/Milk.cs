using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example.Decorators
{
    public class Milk : BeverageDecorator
    {
        public Milk(Beverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return $"{_beverage.GetDescription()} + молоко";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.50m;
        }
    }
}
