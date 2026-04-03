using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Example
{
    public interface IPizzaBuilder
    {
        IPizzaBuilder SetSize(Pizza.Size size);
        IPizzaBuilder SetDough(Pizza.DoughType dough);
        IPizzaBuilder SetSauce(Pizza.Sauce sauce);
        IPizzaBuilder SetCheese(Pizza.Cheese cheese);
        IPizzaBuilder AddTopping(Pizza.Topping topping);
        IPizzaBuilder AddExtra(string extra);
        IPizzaBuilder SetCookingLevel(int level);
        Pizza Build();
    }
}
