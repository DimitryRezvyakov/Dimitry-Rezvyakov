using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example.Decorators
{
    public class Syrup : BeverageDecorator
    {
        private string _flavor;

        public Syrup(Beverage beverage, string flavor) : base(beverage)
        {
            _flavor = flavor;
        }

        public override string GetDescription()
        {
            return $"{_beverage.GetDescription()} + {_flavor} сироп";
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost() + 0.70m;
        }
    }
}
