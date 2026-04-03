using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Abstractions
{
    public interface ISofa
    {
        string LieDown();
        int SeatsCount { get; }
        bool IsFoldable { get; }
    }
}
