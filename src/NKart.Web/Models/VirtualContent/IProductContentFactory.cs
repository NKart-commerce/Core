using NKart.Web.Models.ContentEditing;

namespace NKart.Web.Models.VirtualContent
{
    using NKart.Web.Models.ContentEditing;

    /// <summary>
    /// Defines a ProductContentFactory.
    /// </summary>
    internal interface IProductContentFactory
    {
        /// <summary>
        /// The build content.
        /// </summary>
        /// <param name="display">
        /// The display.
        /// </param>
        /// <returns>
        /// The <see cref="IProductContent"/>.
        /// </returns>
        IProductContent BuildContent(ProductDisplay display);
        IProductVariantContent BuildContent(ProductVariantDisplay display);
    }
}