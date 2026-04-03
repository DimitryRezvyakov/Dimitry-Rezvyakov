using AbstractFactory.Example.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Products.IkeaProducts
{
    public class IkeaChair : IChair
    {
        public bool HasArmrests => true;
        public string Material => "Дерево";

        public string Sit()
        {
            return "Сижу на стуле Ikea — удобно и экологично!";
        }
    }
}
