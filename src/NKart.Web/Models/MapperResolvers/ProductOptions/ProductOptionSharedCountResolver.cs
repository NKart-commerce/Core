using NKart.Web.Models.ContentEditing;

namespace NKart.Web.Models.MapperResolvers.ProductOptions
{
    using AutoMapper;

    using NKart.Core;
    using NKart.Core.Models;
    using NKart.Core.Services;
    using NKart.Web.Models.ContentEditing;

    /// <summary>
    /// Maps the shared count field to <see cref="ProductOptionDisplay"/>.
    /// </summary>
    public class ProductOptionSharedCountResolver : ValueResolver<IProductOption, int>
    {
        /// <summary>
        /// Gets the sharedCount field value.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The number of times the option has been shared (used).
        /// </returns>
        protected override int ResolveCore(IProductOption source)
        {
            return source.Shared
                       ? MerchelloContext.Current.Services.ProductOptionService.GetProductOptionShareCount(source)
                       : 1;  // one because it is associated with a single product
        }
    }
}