using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Example
{
    public abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract decimal GetCost();

        public virtual string Prepare()
        {
            return $"Приготовление: {GetDescription()}";
        }
    }
}
