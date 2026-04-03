using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Example
{
    public interface IDeliveryStrategy
    {
        decimal CalculateCost(Order order);
        string GetDeliveryName();
        int GetEstimatedDays();
    }
}
