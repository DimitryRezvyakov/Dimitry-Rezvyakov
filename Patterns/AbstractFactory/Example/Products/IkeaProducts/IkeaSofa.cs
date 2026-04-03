using AbstractFactory.Example.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Products.IkeaProducts
{
    public class IkeaSofa : ISofa
    {
        public int SeatsCount => 3;
        public bool IsFoldable => true;

        public string LieDown()
        {
            return "Лежу на диване Ikea — мягко, есть место для гостей!";
        }
    }
}
