using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Mappers
{
    internal sealed class NotificationMethodMapper : MerchelloBaseMapper
    {
        public NotificationMethodMapper()
        {
            BuildMap();
        }

        internal override void BuildMap()
        {
            if (!PropertyInfoCache.IsEmpty) return;

            CacheMap<NotificationMethod, NotificationMethodDto>(src => src.Key, dto => dto.Key);
            CacheMap<NotificationMethod, NotificationMethodDto>(src => src.ProviderKey, dto => dto.ProviderKey);
            CacheMap<NotificationMethod, NotificationMethodDto>(src => src.Name, dto => dto.Name);
            CacheMap<NotificationMethod, NotificationMethodDto>(src => src.Description, dto => dto.Description);
            CacheMap<NotificationMethod, NotificationMethodDto>(src => src.ServiceCode, dto => dto.ServiceCode);
            CacheMap<NotificationMethod, NotificationMethodDto>(src => src.UpdateDate, dto => dto.UpdateDate);
            CacheMap<NotificationMethod, NotificationMethodDto>(src => src.CreateDate, dto => dto.CreateDate);
        }
    }
}