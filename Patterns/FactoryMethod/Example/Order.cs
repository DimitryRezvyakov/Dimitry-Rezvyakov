using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example
{
    public abstract class Order
    {
        public int OrderId { get; set; }
        public List<string> Items { get; set; } = new();
        public decimal TotalPrice { get; protected set; }

        public abstract decimal CalculateTotal();
        public abstract string GetReceipt();
        public abstract int GetEstimatedTime();

        public void AddItem(string item, decimal price)
        {
            Items.Add(item);
            TotalPrice += price;
        }
    }
}
