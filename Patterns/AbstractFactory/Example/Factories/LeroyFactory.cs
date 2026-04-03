using AbstractFactory.Example.Abstractions;
using AbstractFactory.Example.Products.LeroyMerlinProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Factories
{
    public class LeroyFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new LeroyChair();
        public ITable CreateTable() => new LeroyTable();
        public ISofa CreateSofa() => new LeroySofa();

        public string GetBrandInfo() => "Leroy Merlin — ваш помощник в ремонте";
    }
}
