using NKart.Web.Models.Ui.Rendering;

namespace NKart.Web.Models
{
    using NKart.Core.Models.Interfaces;
    using NKart.Web.Models.Ui.Rendering;

    /// <summary>
    /// The product collection.
    /// </summary>
    public class ProductCollection : EntityCollectionProxyBase, IProductCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollection"/> class.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        public ProductCollection(IEntityCollection collection) 
            : base(collection)
        {
        }
    }
}