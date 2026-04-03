using FactoryMethod.Example.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example.OrderCreators
{
    public class PickupOrderCreator : OrderCreator
    {
        private string _pickupPoint;

        public PickupOrderCreator(string pickupPoint)
        {
            _pickupPoint = pickupPoint;
        }

        public override Order CreateOrder()
        {
            return new PickupOrder
            {
                PickupPoint = _pickupPoint
            };
        }
    }
}
