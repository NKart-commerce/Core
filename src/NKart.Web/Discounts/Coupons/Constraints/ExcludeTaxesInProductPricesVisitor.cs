namespace NKart.Web.Discounts.Coupons.Constraints
{
    using NKart.Core;
    using NKart.Core.Models;

    /// <summary>
    /// Removes taxes from product line items.
    /// </summary>
    internal class ExcludeTaxesInProductPricesVisitor : ILineItemVisitor
    {
        /// <summary>
        /// The visit.
        /// </summary>
        /// <param name="lineItem">
        /// The line item.
        /// </param>
        public void Visit(ILineItem lineItem)
        {
            if (lineItem.LineItemType != LineItemType.Product || !lineItem.ExtendedData.TaxIncludedInProductPrice()) return;

            lineItem.Price = lineItem.ExtendedData.GetOnSaleValue() ? 
                lineItem.ExtendedData.ProductPreTaxSalePrice() : 
                lineItem.ExtendedData.ProductPreTaxPrice();
        }
    }
}