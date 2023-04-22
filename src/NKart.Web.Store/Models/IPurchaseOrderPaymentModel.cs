namespace NKart.Web.Store.Models
{
    using NKart.Web.Models.Ui;

    /// <summary>
    /// Represents a Purchase Order Payment Model.
    /// </summary>
    public interface IPurchaseOrderPaymentModel : ICheckoutPaymentModel
    {
        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        string PurchaseOrderNumber { get; set; }
    }
}