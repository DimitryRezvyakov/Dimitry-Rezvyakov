using AbstractFactory.Example.Abstractions;
using AbstractFactory.Example.Products.IkeaProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Factories
{
    public class IkeaFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new IkeaChair();
        public ITable CreateTable() => new IkeaTable();
        public ISofa CreateSofa() => new IkeaSofa();

        public string GetBrandInfo() => "Ikea — шведское качество по доступным ценам";
    }
}
