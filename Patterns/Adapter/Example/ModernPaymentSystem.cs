using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Example
{
    public interface IModernPaymentAPI
    {
        PaymentResult ProcessPayment(PaymentRequest request);
        PaymentStatus CheckStatus(string paymentId);
    }

    public class PaymentRequest
    {
        public string CardHolderName { get; set; }
        public string CardPan { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvv { get; set; }
        public Money Amount { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }

    public class Money
    {
        public decimal Value { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class PaymentResult
    {
        public bool Success { get; set; }
        public string PaymentId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ProcessedAt { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public class ModernPaymentSystem : IModernPaymentAPI
    {
        public PaymentResult ProcessPayment(PaymentRequest request)
        {
            Console.WriteLine($"[ModernPaymentSystem] Обработка платежа: {request.Amount.Value} {request.Amount.CurrencyCode}");
            Console.WriteLine($"[ModernPaymentSystem] Держатель карты: {request.CardHolderName}");

            if (string.IsNullOrEmpty(request.CardPan) || request.CardPan.Length < 16)
            {
                return new PaymentResult
                {
                    Success = false,
                    ErrorCode = "INVALID_CARD",
                    ErrorMessage = "Неверный номер карты",
                    ProcessedAt = DateTime.Now
                };
            }

            if (request.Amount.Value <= 0)
            {
                return new PaymentResult
                {
                    Success = false,
                    ErrorCode = "INVALID_AMOUNT",
                    ErrorMessage = "Сумма должна быть положительной",
                    ProcessedAt = DateTime.Now
                };
            }

            return new PaymentResult
            {
                Success = true,
                PaymentId = $"MOD-{Guid.NewGuid()}",
                ProcessedAt = DateTime.Now
            };
        }

        public PaymentStatus CheckStatus(string paymentId)
        {
            return PaymentStatus.Completed;
        }
    }
}
