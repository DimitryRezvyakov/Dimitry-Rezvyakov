using AbstractFactory.Example.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Products.IkeaProducts
{
    public class IkeaTable : ITable
    {
        public int MaxWeight => 100;

        public string PlaceItem(string item)
        {
            return $"Ставлю {item} на стол Ikea. Прочная конструкция!";
        }

        public string GetDimensions()
        {
            return "120x70x75 см";
        }
    }
}
