using FactoryMethod.Example.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example.OrderCreators
{
    public class DineInOrderCreator : OrderCreator
    {
        private int _tableNumber;

        public DineInOrderCreator(int tableNumber)
        {
            _tableNumber = tableNumber;
        }

        public override Order CreateOrder()
        {
            return new DineInOrder
            {
                TableNumber = _tableNumber,
            };
        }
    }
}
