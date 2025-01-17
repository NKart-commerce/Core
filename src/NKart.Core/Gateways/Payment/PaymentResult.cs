﻿using NKart.Core.Models;

namespace NKart.Core.Gateways.Payment
{
    using NKart.Core.Models;
    using Umbraco.Core;

    /// <summary>
    /// Represents a Result
    /// </summary>
    public class PaymentResult : IPaymentResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentResult"/> class.
        /// </summary>
        /// <param name="payment">
        /// The payment.
        /// </param>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        /// <param name="approveOrderCreation">
        /// The approve order creation.
        /// </param>
        public PaymentResult(Attempt<IPayment> payment, IInvoice invoice, bool approveOrderCreation)
            : this(payment, invoice, approveOrderCreation, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentResult"/> class.
        /// </summary>
        /// <param name="payment">
        /// The payment.
        /// </param>
        /// <param name="invoice">
        /// The invoice.
        /// </param>
        /// <param name="approveOrderCreation">
        /// The approve order creation.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect URL.
        /// </param>
        public PaymentResult(Attempt<IPayment> payment, IInvoice invoice, bool approveOrderCreation, string redirectUrl)
        {
            Payment = payment;
            Invoice = invoice;
            ApproveOrderCreation = approveOrderCreation;
            RedirectUrl = redirectUrl;
        }

        /// <summary>
        /// Gets the Result
        /// </summary>
        public Attempt<IPayment> Payment { get; private set; }

        /// <summary>
        /// Gets the invoice.
        /// </summary>
        public IInvoice Invoice { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not an order should be generated
        /// as a result of this payment
        /// </summary>
        public bool ApproveOrderCreation { get; internal set; }

        /// <summary>
        /// Gets the redirect URL.
        /// </summary>
        public string RedirectUrl { get; internal set; }
    }
}