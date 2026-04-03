using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Example.Strategies
{
    public class CourierDeliveryStrategy : IDeliveryStrategy
    {
        public decimal CalculateCost(Order order)
        {
            var cost = 300 + (order.Distance * 30);
            return Math.Max(cost, 500);
        }

        public string GetDeliveryName() => "Курьер";

        public int GetEstimatedDays() => 2;
    }
}
