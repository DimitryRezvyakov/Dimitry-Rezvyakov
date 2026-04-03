using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example
{
    public abstract class OrderCreator
    {
        public abstract Order CreateOrder();

        public void ProcessOrder(int orderId, List<(string name, decimal price)> items)
        {
            var order = CreateOrder();
            order.OrderId = orderId;

            foreach (var item in items)
            {
                order.AddItem(item.name, item.price);
            }

            Console.WriteLine(order.GetReceipt());
            Console.WriteLine($"Итоговая сумма к оплате: {order.CalculateTotal():C}");
            Console.WriteLine("Заказ принят в обработку!\n");
        }
    }
}
