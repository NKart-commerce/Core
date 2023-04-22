namespace NKart.Web.DataModifiers.Product
{
    using NKart.Core;
    using NKart.Core.Gateways.Taxation;
    using NKart.Core.Models;

    /// <summary>
    /// The product variant data modifier extensions.
    /// </summary>
    internal static class ProductVariantDataModifierExtensions
    {
        /// <summary>
        /// The alters the product with taxation results.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public static void AlterProduct(this IProductVariantDataModifierData value, IProductTaxCalculationResult result)
        {
            value.ModifyData("Price", value.Price + result.PriceResult.TaxAmount, result.PriceResult.ExtendedData);
            value.ModifyData("SalePrice", value.SalePrice + result.SalePriceResult.TaxAmount, result.SalePriceResult.ExtendedData);
        }
    }
}