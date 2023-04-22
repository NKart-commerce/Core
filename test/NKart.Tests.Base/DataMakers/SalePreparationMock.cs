using NKart.Core;
using NKart.Core.Gateways.Payment;
using NKart.Core.Models;
using NKart.Core.Sales;

namespace NKart.Tests.Base.DataMakers
{
    using global::Umbraco.Core;

    using NKart.Core.Marketing.Offer;

    internal class SalePreparationMock : SalePreparationBase
    {
        public SalePreparationMock(IMerchelloContext merchelloContext, IItemCache itemCache, ICustomerBase customer) 
            : base(merchelloContext, itemCache, customer)
        {

        }

        internal override Attempt<IOfferResult<TConstraint, TAward>> TryApplyOffer<TConstraint, TAward>(TConstraint validateAgainst, string offerCode)
        {
            throw new System.NotImplementedException();
        }
    }
}