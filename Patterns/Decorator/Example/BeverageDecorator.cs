using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example
{
    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage _beverage;

        protected BeverageDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription();
        }

        public override decimal GetCost()
        {
            return _beverage.GetCost();
        }
    }
}
