using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Factories
{
    internal class StoreSettingFactory : IEntityFactory<IStoreSetting, StoreSettingDto>
    {
        public IStoreSetting BuildEntity(StoreSettingDto dto)
        {
            var entity = new StoreSetting()
            {
                Key = dto.Key,
                Name = dto.Name,
                Value = dto.Value,
                TypeName = dto.TypeName,
                CreateDate = dto.CreateDate,
                UpdateDate = dto.UpdateDate
            };

            entity.ResetDirtyProperties();

            return entity;
        }

        public StoreSettingDto BuildDto(IStoreSetting entity)
        {
            return new StoreSettingDto()
            {
                Key = entity.Key,
                Name = entity.Name,
                Value = entity.Value,
                TypeName = entity.TypeName,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate
            };
        }
    }
}