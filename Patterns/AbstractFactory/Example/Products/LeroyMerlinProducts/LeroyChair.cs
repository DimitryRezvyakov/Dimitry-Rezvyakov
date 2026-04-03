using AbstractFactory.Example.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Example.Products.LeroyMerlinProducts
{
    public class LeroyChair : IChair
    {
        public bool HasArmrests => false;
        public string Material => "Пластик";

        public string Sit()
        {
            return "Сижу на стуле Leroy Merlin — легкий и практичный!";
        }
    }
}
