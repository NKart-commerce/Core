using Newtonsoft.Json;
using NKart.Core.Models;
using NKart.Core.Models.Interfaces;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Factories
{
    internal class ShipMethodFactory : IEntityFactory<IShipMethod, ShipMethodDto>
    {
        public IShipMethod BuildEntity(ShipMethodDto dto)
        {
            var deserialized = JsonConvert.DeserializeObject<ProvinceCollection<ShipProvince>>(dto.ProvinceData);
            // TODO : fix this mapping
            var provinces = new ProvinceCollection<IShipProvince>();
            foreach (var p in deserialized)
            {
                provinces.Add(p);
            }

            var shipMethod = new ShipMethod(dto.ProviderKey, dto.ShipCountryKey)
            {
                Key = dto.Key,
                Name = dto.Name,              
                Surcharge = dto.Surcharge,
                ServiceCode = dto.ServiceCode,
                Taxable = dto.Taxable,
                Provinces = provinces,
                UpdateDate = dto.UpdateDate,
                CreateDate = dto.CreateDate
            };

            shipMethod.ResetDirtyProperties();

            return shipMethod;
        }

        public ShipMethodDto BuildDto(IShipMethod entity)
        {
            var provinceData = JsonConvert.SerializeObject(entity.Provinces);
            var dto = new ShipMethodDto()
            {
                Key = entity.Key,
                Name = entity.Name,
                ProviderKey = entity.ProviderKey,
                ShipCountryKey = entity.ShipCountryKey,
                Surcharge = entity.Surcharge,
                ServiceCode = entity.ServiceCode,
                Taxable = entity.Taxable,
                ProvinceData = provinceData,
                UpdateDate = entity.UpdateDate,
                CreateDate = entity.CreateDate                
            };

            return dto;
        }
    }
}
