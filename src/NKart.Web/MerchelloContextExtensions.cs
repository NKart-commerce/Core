namespace NKart.Web
{
    using NKart.Core;
    using NKart.Core.Gateways.Taxation;
    using NKart.Core.Models;
    using NKart.Web.Models.ContentEditing;

    /// <summary>
    /// Extension methods for the <see cref="IMerchelloContext"/>.
    /// </summary>
    public static class MerchelloContextExtensions
    {
        /// <summary>
        /// Calculates taxes for a product.
        /// </summary>
        /// <param name="context">
        /// The <see cref="ITaxationContext"/>.
        /// </param>
        /// <param name="product">
        /// The <see cref="IProduct"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ITaxCalculationResult"/>.
        /// </returns>
        public static IProductTaxCalculationResult CalculateTaxesForProduct(this ITaxationContext context, IProduct product)
        {
            return context.CalculateTaxesForProduct(product.ToProductDisplay());
        }

        /// <summary>
        /// Calculates taxes for a product variant.
        /// </summary>
        /// <param name="context">
        /// The <see cref="ITaxationContext"/>.
        /// </param>
        /// <param name="productVariant">
        /// The <see cref="IProductVariant"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ITaxCalculationResult"/>.
        /// </returns>
        public static IProductTaxCalculationResult CalculateTaxesForProduct(this ITaxationContext context, IProductVariant productVariant)
        {
            return context.CalculateTaxesForProduct(productVariant.ToProductVariantDisplay());
        }
    }
}