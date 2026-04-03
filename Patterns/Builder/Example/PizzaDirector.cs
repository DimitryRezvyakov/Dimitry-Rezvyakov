using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Example
{
    public class PizzaDirector
    {
        private IPizzaBuilder _builder;

        public PizzaDirector(IPizzaBuilder builder)
        {
            _builder = builder;
        }

        public Pizza MakeMargherita()
        {
            return _builder
                .SetSize(Pizza.Size.Medium)
                .SetDough(Pizza.DoughType.Traditional)
                .SetSauce(Pizza.Sauce.Tomato)
                .SetCheese(Pizza.Cheese.Mozzarella)
                .SetCookingLevel(3)
                .Build();
        }

        public Pizza MakePepperoni()
        {
            return _builder
                .SetSize(Pizza.Size.Large)
                .SetDough(Pizza.DoughType.Thin)
                .SetSauce(Pizza.Sauce.Tomato)
                .SetCheese(Pizza.Cheese.Mozzarella)
                .AddTopping(Pizza.Topping.Pepperoni)
                .AddTopping(Pizza.Topping.Ham)
                .SetCookingLevel(4)
                .Build();
        }

        public Pizza MakeVeggie()
        {
            return _builder
                .SetSize(Pizza.Size.Medium)
                .SetDough(Pizza.DoughType.Thin)
                .SetSauce(Pizza.Sauce.Pesto)
                .SetCheese(Pizza.Cheese.Mixed)
                .AddTopping(Pizza.Topping.Mushrooms)
                .AddTopping(Pizza.Topping.Olives)
                .AddTopping(Pizza.Topping.Onions)
                .AddTopping(Pizza.Topping.Peppers)
                .SetCookingLevel(3)
                .Build();
        }

        public Pizza MakeMeatLovers()
        {
            return _builder
                .SetSize(Pizza.Size.Family)
                .SetDough(Pizza.DoughType.CheesyCrust)
                .SetSauce(Pizza.Sauce.Barbecue)
                .SetCheese(Pizza.Cheese.Cheddar)
                .AddTopping(Pizza.Topping.Pepperoni)
                .AddTopping(Pizza.Topping.Ham)
                .AddTopping(Pizza.Topping.Bacon)
                .AddTopping(Pizza.Topping.Chicken)
                .SetCookingLevel(4)
                .Build();
        }

        public Pizza MakeCustom(Action<IPizzaBuilder> configure)
        {
            configure(_builder);
            return _builder.Build();
        }
    }
}
