using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Abstractions
{
    public interface ITable
    {
        string PlaceItem(string item);
        int MaxWeight { get; }
        string GetDimensions();
    }
}
