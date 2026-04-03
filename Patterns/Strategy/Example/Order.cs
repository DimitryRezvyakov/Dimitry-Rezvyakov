using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Example
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal Weight { get; set; }        
        public decimal Distance { get; set; }      
        public decimal ProductsTotal { get; set; } 
        public bool IsUrgent { get; set; }

        private IDeliveryStrategy _deliveryStrategy;

        public void SetDeliveryStrategy(IDeliveryStrategy strategy)
        {
            _deliveryStrategy = strategy;
        }

        public decimal CalculateDeliveryCost()
        {
            if (_deliveryStrategy == null)
                throw new InvalidOperationException("Стратегия доставки не выбрана");

            return _deliveryStrategy.CalculateCost(this);
        }

        public string GetDeliveryInfo()
        {
            return $"{_deliveryStrategy.GetDeliveryName()} — " +
                   $"стоимость: {CalculateDeliveryCost():C}, " +
                   $"срок: {_deliveryStrategy.GetEstimatedDays()} дней";
        }
    }
}
