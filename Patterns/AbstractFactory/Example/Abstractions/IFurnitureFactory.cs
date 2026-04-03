using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Abstractions
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
        ISofa CreateSofa();

        string GetBrandInfo();
    }
}
