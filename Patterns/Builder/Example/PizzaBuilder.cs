using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Example
{
    public class PizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new();

        public IPizzaBuilder SetSize(Pizza.Size size)
        {
            _pizza.PizzaSize = size;
            return this;
        }

        public IPizzaBuilder SetDough(Pizza.DoughType dough)
        {
            _pizza.Dough = dough;
            return this;
        }

        public IPizzaBuilder SetSauce(Pizza.Sauce sauce)
        {
            _pizza.PizzaSauce = sauce;
            return this;
        }

        public IPizzaBuilder SetCheese(Pizza.Cheese cheese)
        {
            _pizza.PizzaCheese = cheese;
            return this;
        }

        public IPizzaBuilder AddTopping(Pizza.Topping topping)
        {
            _pizza.Toppings.Add(topping);
            return this;
        }

        public IPizzaBuilder AddExtra(string extra)
        {
            _pizza.Extras.Add(extra);
            return this;
        }

        public IPizzaBuilder SetCookingLevel(int level)
        {
            _pizza.CookingLevel = Math.Clamp(level, 1, 5);
            return this;
        }

        public Pizza Build()
        {
            Validate();

            var result = _pizza;
            _pizza = new Pizza();
            return result;
        }

        private void Validate()
        {
            if (_pizza.PizzaSize == 0)
                throw new InvalidOperationException("Не выбран размер пиццы");

            if (_pizza.Dough == 0)
                throw new InvalidOperationException("Не выбран тип теста");

            // Нельзя выбрать сыр без соуса
            if (_pizza.PizzaCheese != Pizza.Cheese.None && _pizza.PizzaSauce == Pizza.Sauce.None)
                throw new InvalidOperationException("Для сыра нужно выбрать соус");

            // Нельзя добавить ананас с морепродуктами (вкусовое ограничение)
            if (_pizza.Toppings.Contains(Pizza.Topping.Pineapple) &&
                _pizza.Toppings.Contains(Pizza.Topping.Seafood))
            {
                throw new InvalidOperationException("Ананас и морепродукты не сочетаются!");
            }
        }
    }
}
