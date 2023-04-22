using NKart.Web.Models;
using NKart.Web.Models.VirtualContent;

namespace NKart.Web.Search
{
    using NKart.Web.Models;
    using NKart.Web.Models.VirtualContent;

    /// <summary>
    /// Marker interface for a ProductContentQueryBuilder.
    /// </summary>
    public interface IProductContentQueryBuilder : ICmsContentQueryBuilder<IProductCollection, IProductFilter, IProductContent>
    {
        /// <summary>
        /// Sets the price range constraints.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        void SetPriceRange(decimal min, decimal max);

        /// <summary>
        /// Clears the price range constraints.
        /// </summary>
        void ClearPriceRange();

        /// <summary>
        /// Include unavailable products
        /// </summary>
        void IncludeUnvailable();

        /// <summary>
        /// Exclude unvailable products (this is the default)
        /// </summary>
        void ExcludeUnvailable();
    }
}