using AbstractFactory.Example.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Products.LeroyMerlinProducts
{
    public class LeroyTable : ITable
    {
        public int MaxWeight => 80;

        public string PlaceItem(string item)
        {
            return $"Размещаю {item} на столе Leroy Merlin. Устойчивая поверхность!";
        }

        public string GetDimensions()
        {
            return "100x60x74 см";
        }
    }
}
