using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Factories
{
    using NKart.Core.Models;
    using NKart.Core.Models.Interfaces;
    using NKart.Core.Models.Rdbms;

    /// <summary>
    /// The warehouse catalog factory.
    /// </summary>
    internal class WarehouseCatalogFactory : IEntityFactory<IWarehouseCatalog, WarehouseCatalogDto>
    {
        /// <summary>
        /// The build entity.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The <see cref="IWarehouseCatalog"/>.
        /// </returns>
        public IWarehouseCatalog BuildEntity(WarehouseCatalogDto dto)
        {            
            var entity = new WarehouseCatalog(dto.WarehouseKey)
            {
                Key = dto.Key,
                Name = dto.Name,
                Description = dto.Description,
                UpdateDate = dto.UpdateDate,
                CreateDate = dto.CreateDate
            };
            entity.ResetDirtyProperties();
            return entity;
        }

        /// <summary>
        /// The build dto.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="WarehouseCatalogDto"/>.
        /// </returns>
        public WarehouseCatalogDto BuildDto(IWarehouseCatalog entity)
        {           
            return new WarehouseCatalogDto()
            {
                Key = entity.Key,
                WarehouseKey = entity.WarehouseKey,
                Name = entity.Name,
                Description = entity.Description,
                UpdateDate = entity.UpdateDate,
                CreateDate = entity.CreateDate
            };
        }
    }
}