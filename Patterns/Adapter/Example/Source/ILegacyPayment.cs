using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Example.Source
{
    public interface ILegacyPayment
    {
        bool Pay(string cardNumber, decimal amount, string currency);
        string GetTransactionId();
        string GetLastError();
    }
}
