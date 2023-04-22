using System;
using NKart.Core;
using NKart.Core.Models;

namespace NKart.Tests.Base.DataMakers
{
    /// <summary>
    /// Helper class to assist in putting together payment data for testing
    /// </summary>
    public class MockPaymentDataMaker : MockDataMakerBase
    {
        public static IPayment PaymentForInserting(Guid paymentMethodKey, PaymentMethodType paymentMethodType, decimal amount, Guid? customerKey = null)
        {
            var payment = new Payment(paymentMethodType, amount, paymentMethodKey)
            {
                CustomerKey = customerKey
            };

            return payment;
        }
    }
}