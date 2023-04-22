using NKart.Web.Models.ContentEditing;

namespace NKart.Web.Models.Ui.Rendering
{
    using System;
    using System.Collections.Generic;

    using NKart.Web.Models.ContentEditing;

    /// <summary>
    /// Defines a customer sales history.
    /// </summary>
    public interface ICustomerSalesHistory : IEnumerable<InvoiceDisplay>
    {
        /// <summary>
        /// Gets the customer key.
        /// </summary>
        Guid CustomerKey { get; }

        /// <summary>
        /// Gets the total outstanding.
        /// </summary>
        decimal TotalOutstanding { get; }

        /// <summary>
        /// Gets the total paid.
        /// </summary>
        decimal TotalPaid { get; }

        /// <summary>
        /// Gets the total purchases.
        /// </summary>
        decimal TotalPurchases { get; }
    }
}