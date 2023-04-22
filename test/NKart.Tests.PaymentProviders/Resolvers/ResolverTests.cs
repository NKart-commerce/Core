namespace NKart.Tests.PaymentProviders.Resolvers
{
    using System.Linq;

    using NKart.Core;
    using NKart.Core.Gateways;
    using NKart.Core.Gateways.Payment;
    using NKart.Providers.Payment.PayPal.Provider;
    using NKart.Tests.Base.TestHelpers;

    using NUnit.Framework;

    using Umbraco.Core;

    [TestFixture]
    public class ResolverTests : MerchelloAllInTestBase
    {
        [Test]
        public void Can_Resolve_Types()
        {
            var resolved = PluginManager.Current.ResolveTypesWithAttribute<GatewayProviderBase, GatewayProviderActivationAttribute>(false);


            Assert.IsTrue(resolved.Any());
        }

        [Test]
        public void Can_Resolve_Payment_Providers()
        {
            //// Arrange
            var expected = 3;

            //// Act
            var providers = MerchelloContext.Current.Gateways.Payment.GetAllProviders();

            //// Assert
            Assert.AreEqual(expected, providers.Count());
        }
    }
}