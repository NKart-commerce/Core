namespace NKart.Tests.Base.Offers
{
    using System;

    using global::Umbraco.Core;

    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;
    using NKart.Core.Models.Interfaces;
    using NKart.Core.Services;
    using NKart.Web.Trees;

    [BackOfficeTree("offers", "tests", "Test Title", "Test Icon", "/fictious/path", 1)]
    public class TestOfferManager : OfferManagerBase<TestOffer> 
    {
        public TestOfferManager(IOfferSettingsService offerSettingsService)
            : base(offerSettingsService)
        {
        }

        public override Guid Key
        {
            get { return new Guid("AD4E890D-9D60-442A-A19A-6FE9EE3A1454"); }
        }

        public override Attempt<TestOffer> GetByOfferCode(string offerCode, ICustomerBase customer)
        {
            throw new NotImplementedException();
        }

        protected override TestOffer GetInstance(IOfferSettings offerSettings)
        {
            return new TestOffer(offerSettings);
        }
    }
}