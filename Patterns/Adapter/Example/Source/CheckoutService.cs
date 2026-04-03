using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Example.Source
{
    public class CheckoutService
    {
        private readonly ILegacyPayment _paymentSystem;

        public CheckoutService(ILegacyPayment paymentSystem)
        {
            _paymentSystem = paymentSystem;
        }

        public bool ProcessOrder(Order order)
        {
            Console.WriteLine($"Обработка заказа #{order.OrderId} на сумму {order.Amount} {order.Currency}");

            bool success = _paymentSystem.Pay(order.CardNumber, order.Amount, order.Currency);

            if (success)
            {
                Console.WriteLine($"Платеж успешен. ID транзакции: {_paymentSystem.GetTransactionId()}");
                return true;
            }
            else
            {
                Console.WriteLine($"Ошибка платежа: {_paymentSystem.GetLastError()}");
                return false;
            }
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
