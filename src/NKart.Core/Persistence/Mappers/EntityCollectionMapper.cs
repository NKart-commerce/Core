using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Mappers
{
    using NKart.Core.Models;
    using NKart.Core.Models.Rdbms;

    /// <summary>
    /// The entity collection mapper.
    /// </summary>
    internal sealed class EntityCollectionMapper : MerchelloBaseMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollectionMapper"/> class.
        /// </summary>
        public EntityCollectionMapper()
        {
            this.BuildMap();
        }

        /// <summary>
        /// The build map.
        /// </summary>
        internal override void BuildMap()
        {
            if (!PropertyInfoCache.IsEmpty) return;

            CacheMap<EntityCollection, EntityCollectionDto>(src => src.Key, dto => dto.Key);
            CacheMap<EntityCollection, EntityCollectionDto>(src => src.EntityTfKey, dto => dto.EntityTfKey);
            CacheMap<EntityCollection, EntityCollectionDto>(src => src.ParentKey, dto => dto.ParentKey);
            CacheMap<EntityCollection, EntityCollectionDto>(src => src.ProviderKey, dto => dto.ProviderKey);
            CacheMap<EntityCollection, EntityCollectionDto>(src => src.Name, dto => dto.Name);
            CacheMap<EntityCollection, EntityCollectionDto>(src => src.SortOrder, dto => dto.SortOrder);
            CacheMap<EntityCollection, EntityCollectionDto>(src => src.UpdateDate, dto => dto.UpdateDate);
            CacheMap<EntityCollection, EntityCollectionDto>(src => src.CreateDate, dto => dto.CreateDate);
        }
    }
}