using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Mappers
{
    /// <summary>
    /// Represents a <see cref="Product"/> to DTO mapper used to translate the properties of the public api 
    /// implementation to that of the database's DTO as sql: [tableName].[columnName].
    /// </summary>
    internal  sealed class ProductMapper : MerchelloBaseMapper
    {
        public ProductMapper()
        {
            BuildMap();
        }

        internal override void BuildMap()
        {
            if (!PropertyInfoCache.IsEmpty) return;

            CacheMap<Product, ProductDto>(src => src.Key, dto => dto.Key);
            CacheMap<Product, ProductDto>(src => src.UpdateDate, dto => dto.UpdateDate);
            CacheMap<Product, ProductDto>(src => src.CreateDate, dto => dto.CreateDate);
        }
    }
}