using AbstractFactory.Example.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Products.LeroyMerlinProducts
{
    public class LeroySofa : ISofa
    {
        public int SeatsCount => 2;
        public bool IsFoldable => false;

        public string LieDown()
        {
            return "Лежу на диване Leroy Merlin — компактный для маленькой квартиры!";
        }
    }
}
