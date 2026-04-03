using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Abstractions
{
    public interface IChair
    {
        string Sit();
        bool HasArmrests { get; }
        string Material { get; }
    }
}
