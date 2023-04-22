using NKart.Web.Models.ContentEditing;

namespace NKart.Web.Models.Reports
{
    using System;
    using System.Collections.Generic;

    using NKart.Web.Models.ContentEditing;

    /// <summary>
    /// The sales by item result.
    /// </summary>
    public class SalesByItemResult : MonthlyReportResult
    {
        /// <summary>
        /// Gets or sets the product variant.
        /// </summary>
        public ProductVariantDisplay ProductVariant { get; set; }

        /// <summary>
        /// Gets or sets the invoice count.
        /// </summary>
        public long InvoiceCount { get; set; }

        /// <summary>
        /// Gets or sets the quantity sold.
        /// </summary>
        public long QuantitySold { get; set; }

        /// <summary>
        /// Gets or sets the totals.
        /// </summary>
        public IEnumerable<ResultCurrencyValue> Totals { get; set; } 
    }
}