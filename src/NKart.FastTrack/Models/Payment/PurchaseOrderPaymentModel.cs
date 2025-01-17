﻿namespace NKart.FastTrack.Models.Payment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using NKart.Web.Store.Models;

    /// <summary>
    /// Represents a purchase order payment.
    /// </summary>
    public class PurchaseOrderPaymentModel : FastTrackPaymentModel, IPurchaseOrderPaymentModel
    {
        /// <summary>
        /// Gets or sets the PO number.
        /// </summary>
        [Required]
        [DisplayName(@"Purchase Order Number")]
        public string PurchaseOrderNumber { get; set; }
    }
}
