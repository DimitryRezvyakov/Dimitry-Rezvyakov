using Adapter.Example.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Example
{
    public class LegacyToModernAdapter : IModernPaymentAPI
    {
        private readonly ILegacyPayment _legacyPayment;

        public LegacyToModernAdapter(ILegacyPayment legacyPayment)
        {
            _legacyPayment = legacyPayment;
        }

        public PaymentResult ProcessPayment(PaymentRequest request)
        {
            bool success = _legacyPayment.Pay(
                request.CardPan,
                request.Amount.Value,
                request.Amount.CurrencyCode
            );

            return new PaymentResult
            {
                Success = success,
                PaymentId = success ? _legacyPayment.GetTransactionId() : null,
                ErrorMessage = success ? null : _legacyPayment.GetLastError(),
                ProcessedAt = DateTime.Now
            };
        }

        public PaymentStatus CheckStatus(string paymentId)
        {
            return PaymentStatus.Completed;
        }
    }
}
