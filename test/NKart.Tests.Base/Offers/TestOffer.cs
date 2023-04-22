namespace NKart.Tests.Base.Offers
{
    using global::Umbraco.Core;

    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;
    using NKart.Core.Models.Interfaces;

    public class TestOffer : OfferBase 
    {
        public TestOffer(IOfferSettings settings)
            : base(settings)
        {
        }

    }
}