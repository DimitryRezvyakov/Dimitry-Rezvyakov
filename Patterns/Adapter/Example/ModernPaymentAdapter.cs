using Adapter.Example.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Example
{
    public class ModernPaymentAdapter : ILegacyPayment
    {
        private readonly IModernPaymentAPI _modernPayment;
        private PaymentResult _lastResult;

        public ModernPaymentAdapter(IModernPaymentAPI modernPayment)
        {
            _modernPayment = modernPayment;
        }

        public bool Pay(string cardNumber, decimal amount, string currency)
        {
            var request = ConvertToModernRequest(cardNumber, amount, currency);

            _lastResult = _modernPayment.ProcessPayment(request);

            return _lastResult.Success;
        }

        public string GetTransactionId()
        {
            return _lastResult?.PaymentId ?? string.Empty;
        }

        public string GetLastError()
        {
            if (_lastResult == null) return "Платеж не был выполнен";
            return _lastResult.Success ? null : _lastResult.ErrorMessage;
        }

        private PaymentRequest ConvertToModernRequest(string cardNumber, decimal amount, string currency)
        {

            return new PaymentRequest
            {
                CardHolderName = "UNKNOWN",
                CardPan = cardNumber,
                ExpiryMonth = "12",         
                ExpiryYear = "2030",        
                Cvv = "000",                
                Amount = new Money
                {
                    Value = amount,
                    CurrencyCode = currency
                },
                Metadata = new Dictionary<string, string>
                {
                    ["source"] = "legacy_integration",
                    ["migrated_at"] = DateTime.Now.ToString("yyyy-MM-dd")
                }
            };
        }
    }
}
