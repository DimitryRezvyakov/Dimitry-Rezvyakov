using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Example.Source
{
    public class LegacyPaymentSystem : ILegacyPayment
    {
        private string _lastTransactionId;
        private string _lastError;

        public bool Pay(string cardNumber, decimal amount, string currency)
        {
            Console.WriteLine($"[LegacyPaymentSystem] Обработка платежа: {amount} {currency}, карта: {MaskCard(cardNumber)}");

            // Простая валидация
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 16)
            {
                _lastError = "Неверный номер карты";
                return false;
            }

            if (amount <= 0)
            {
                _lastError = "Сумма должна быть положительной";
                return false;
            }

            // Генерируем ID транзакции
            _lastTransactionId = $"LEG-{DateTime.Now.Ticks}";
            _lastError = null;

            return true;
        }

        public string GetTransactionId() => _lastTransactionId;
        public string GetLastError() => _lastError;

        private string MaskCard(string cardNumber)
        {
            if (cardNumber.Length < 8) return "****";
            return $"****-****-****-{cardNumber[^4..]}";
        }
    }
}
