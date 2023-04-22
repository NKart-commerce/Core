namespace NKart.Tests.IntegrationTests.DisplayClasses
{
    using NKart.Core.Marketing.Offer;
    using NKart.Tests.Base.TestHelpers;
    using NKart.Web.Discounts.Coupons;
    using NKart.Web.Models.ContentEditing;

    using NUnit.Framework;

    [TestFixture]
    public class OfferProviderTests : MerchelloAllInTestBase 
    {
        [Test]
        public void Can_Map_An_OfferProvider_To_OfferProviderDisplay()
        {
            //// Arrange
            var provider = OfferProviderResolver.Current.GetOfferProvider<CouponManager>();

            //// Act
            var display = provider.ToOfferProviderDisplay();

            //// Assert
            Assert.NotNull(display);
            Assert.AreEqual("Coupon", display.BackOfficeTree.Title);
        }
    }
}