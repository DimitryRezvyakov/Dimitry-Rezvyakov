using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example.Orders
{
    public class DeliveryOrder : Order
    {
        public string Address { get; set; } = string.Empty;
        public decimal DeliveryFee { get; set; } = 5.99m;

        public override decimal CalculateTotal()
        {
            return TotalPrice + DeliveryFee;
        }

        public override string GetReceipt()
        {
            return $"""
                ===== ЧЕК ДОСТАВКИ =====
                Заказ №{OrderId}
                Адрес: {Address}
                Товары: {string.Join(", ", Items)}
                Сумма: {TotalPrice:C}
                Доставка: {DeliveryFee:C}
                ИТОГО: {CalculateTotal():C}
                Время доставки: {GetEstimatedTime()} мин.
                """;
        }

        public override int GetEstimatedTime()
        {
            return 30 + (Items.Count * 2); // 30 мин + по 2 мин на позицию
        }
    }
}
