using NKart.Core.Models;

namespace NKart.Core.Gateways.Payment
{
    using NKart.Core.Models;

    /// <summary>
    /// The payment operation event data.
    /// </summary>
    public class PaymentOperationData : AuthorizeOperationData
    {
        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        public IPayment Payment { get; set; }
    }
}