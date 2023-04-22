using NKart.Web.Models.Ui.Rendering;

namespace NKart.Web.Models
{
    using NKart.Core.Models.Interfaces;
    using NKart.Web.Models.Ui.Rendering;

    /// <summary>
    /// Represents a product filter.
    /// </summary>
    public class ProductFilter : EntityCollectionProxyBase, IProductFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductFilter"/> class.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        public ProductFilter(IEntityCollection collection)
            : base(collection)
        {
        }
    }
}