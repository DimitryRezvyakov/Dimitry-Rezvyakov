using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example.Orders
{
    public class PickupOrder : Order
    {
        public string PickupPoint { get; set; } = string.Empty;

        public override decimal CalculateTotal()
        {
            return TotalPrice;
        }

        public override string GetReceipt()
        {
            return $"""
                ===== ЧЕК САМОВЫВОЗА =====
                Заказ №{OrderId}
                Пункт выдачи: {PickupPoint}
                Товары: {string.Join(", ", Items)}
                СУММА: {CalculateTotal():C}
                Готовность через: {GetEstimatedTime()} мин.
                """;
        }

        public override int GetEstimatedTime()
        {
            return 15 + (Items.Count * 1);
        }
    }
}
