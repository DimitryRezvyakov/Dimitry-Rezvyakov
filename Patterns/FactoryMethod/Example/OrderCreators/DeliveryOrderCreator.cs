using FactoryMethod.Example.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example.OrderCreators
{
    public class DeliveryOrderCreator : OrderCreator
    {
        private string _address;

        public DeliveryOrderCreator(string address)
        {
            _address = address;
        }

        public override Order CreateOrder()
        {
            return new DeliveryOrder
            {
                Address = _address,
                DeliveryFee = 5.99m
            };
        }
    }
}
