using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Example
{
    public class Pizza
    {
        // Размеры
        public enum Size { Small, Medium, Large, Family }

        // Типы теста
        public enum DoughType { Thin, Traditional, CheesyCrust }

        // Соусы
        public enum Sauce { Tomato, Creamy, Pesto, Barbecue, None }

        // Сыры
        public enum Cheese { Mozzarella, Parmesan, Cheddar, BlueCheese, Mixed, None }

        // Начинки
        public enum Topping { Pepperoni, Ham, Mushrooms, Olives, Onions, Peppers, Bacon, Pineapple, Seafood, Chicken }

        // Основные свойства
        public Size PizzaSize { get; set; }
        public DoughType Dough { get; set; }
        public Sauce PizzaSauce { get; set; }
        public Cheese PizzaCheese { get; set; }
        public int CookingLevel { get; set; } // 1-5, где 1 - почти сырая, 5 - очень прожаренная

        // Коллекции
        public List<Topping> Toppings { get; set; } = new();
        public List<string> Extras { get; set; } = new(); // дополнительная доставка: соусы, посыпки

        // Стоимость (вычисляется динамически)
        public decimal CalculatePrice()
        {
            decimal price = 0;

            price += PizzaSize switch
            {
                Size.Small => 5.99m,
                Size.Medium => 7.99m,
                Size.Large => 9.99m,
                Size.Family => 12.99m,
                _ => 0
            };

            price += Dough switch
            {
                DoughType.Thin => 0,
                DoughType.Traditional => 1.00m,
                DoughType.CheesyCrust => 2.50m,
                _ => 0
            };

            price += PizzaSauce == Sauce.None ? 0 : 0.50m;
            price += PizzaCheese == Cheese.None ? 0 : 1.00m;
            price += Toppings.Count * 1.50m;
            price += Extras.Count * 0.75m;

            return price;
        }

        public string GetDescription()
        {
            return $"""
                ===== ВАША ПИЦЦА =====
                Размер: {PizzaSize}
                Тесто: {Dough}
                Соус: {PizzaSauce}
                Сыр: {PizzaCheese}
                Начинки: {(Toppings.Any() ? string.Join(", ", Toppings) : "без начинок")}
                Дополнительно: {(Extras.Any() ? string.Join(", ", Extras) : "нет")}
                Прожарка: {CookingLevel}/5
                Стоимость: {CalculatePrice():C}
                """;
        }
    }
}
