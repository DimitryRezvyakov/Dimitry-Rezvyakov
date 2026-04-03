using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Example.Orders
{
    public class DineInOrder : Order
    {
        public int TableNumber { get; set; }
        public decimal ServiceCharge => TotalPrice * 0.10m;

        public override decimal CalculateTotal()
        {
            return TotalPrice + ServiceCharge;
        }

        public override string GetReceipt()
        {
            return $"""
                ===== ЧЕК РЕСТОРАНА =====
                Заказ №{OrderId}
                Столик: {TableNumber}
                Товары: {string.Join(", ", Items)}
                Сумма: {TotalPrice:C}
                Обслуживание: {ServiceCharge:C}
                ИТОГО: {CalculateTotal():C}
                Приятного аппетита!
                """;
        }

        public override int GetEstimatedTime()
        {
            return 10 + (Items.Count * 1);
        }
    }
}
