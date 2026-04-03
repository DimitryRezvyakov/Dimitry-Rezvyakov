using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Example.Strategies
{
    public class PickupStrategy : IDeliveryStrategy
    {
        public decimal CalculateCost(Order order)
        {
            return 0;
        }

        public string GetDeliveryName() => "Самовывоз";

        public int GetEstimatedDays() => 0;
    }
}
