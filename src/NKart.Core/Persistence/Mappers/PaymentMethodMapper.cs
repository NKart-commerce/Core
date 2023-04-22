using NKart.Core.Models;
using NKart.Core.Models.Rdbms;

namespace NKart.Core.Persistence.Mappers
{
    internal sealed class PaymentMethodMapper : MerchelloBaseMapper
    {
        public PaymentMethodMapper()
        {
            BuildMap();
        }

        internal override void BuildMap()
        {
            if (!PropertyInfoCache.IsEmpty) return;

            CacheMap<PaymentMethod, PaymentMethodDto>(src => src.Key, dto => dto.Key);
            CacheMap<PaymentMethod, PaymentMethodDto>(src => src.ProviderKey, dto => dto.ProviderKey);
            CacheMap<PaymentMethod, PaymentMethodDto>(src => src.Name, dto => dto.Name);
            CacheMap<PaymentMethod, PaymentMethodDto>(src => src.Description, dto => dto.Description);
            CacheMap<PaymentMethod, PaymentMethodDto>(src => src.PaymentCode, dto => dto.PaymentCode);
            CacheMap<PaymentMethod, PaymentMethodDto>(src => src.UpdateDate, dto => dto.UpdateDate);
            CacheMap<PaymentMethod, PaymentMethodDto>(src => src.CreateDate, dto => dto.CreateDate);
        }
    }
}