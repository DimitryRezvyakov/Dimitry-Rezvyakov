using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Example.Strategies
{
    public class PostDeliveryStrategy : IDeliveryStrategy
    {
        public decimal CalculateCost(Order order)
        {
            return 200 + (order.Weight * 50);
        }

        public string GetDeliveryName() => "Почта России😂🤣";

        public int GetEstimatedDays() => 7;
    }
}
