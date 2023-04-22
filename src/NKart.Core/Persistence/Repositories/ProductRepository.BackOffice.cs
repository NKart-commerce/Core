using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Repositories
{
    using System;
    using System.Linq;

    using NKart.Core.Models;
    using NKart.Core.Models.Rdbms;
    using NKart.Core.Persistence.Factories;

    using Umbraco.Core.Persistence;

    /// <inheritdoc/>
    internal partial class ProductRepository : IProductBackOfficeRepository
    {
        /// <inheritdoc/>
        public PagedCollection<IProduct> GetRecentlyUpdatedProducts(long page, long itemsPerPage = 10)
        {
            var sql = new Sql().Select("*")
                .From<ProductDto>(SqlSyntax)
                .OrderByDescending<ProductDto>(x => x.UpdateDate, SqlSyntax);

            var results = Database.Page<ProductDto>(page, itemsPerPage, sql);

            var products = results.Items.Any()
                   ? GetAll(results.Items.Select(x => x.Key).ToArray())
                   : Enumerable.Empty<IProduct>();

            return new PagedCollection<IProduct>
                       {
                           CurrentPage = results.CurrentPage,
                           Items = products,
                           PageSize = results.ItemsPerPage,
                           TotalItems = results.TotalItems,
                           TotalPages = results.TotalPages,
                           SortField = "createDate"
                       };
        }
    }
}
