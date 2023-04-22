namespace NKart.Tests.PaymentProviders.Braintree.TestHelpers
{
    using System;

    using global::Braintree;

    using NKart.Core;
    using NKart.Core.Models;
    using NKart.Providers;
    using NKart.Providers.Models;
    using NKart.Providers.Payment.Braintree;
    using NKart.Providers.Payment.Braintree.Models;
    using NKart.Providers.Payment.Braintree.Services;
    using NKart.Providers.Payment.Models;
    using NKart.Tests.Base.TestHelpers;

    using NUnit.Framework;

    public abstract class BraintreeTestBase : MerchelloAllInTestBase
    {
        protected BraintreeProviderSettings BraintreeProviderSettings;

        protected ICustomer TestCustomer;

        protected Guid CustomerKey = new Guid("1A6E8170-9CB9-41C0-B944-36F16B97BED2");

        protected BraintreeGateway Gateway;

        protected IBraintreeApiService BraintreeApiService;


        [TestFixtureSetUp]
        public virtual void TestFixtureSetup()
        {
            this.TestCustomer = MerchelloContext.Current.Services.CustomerService.CreateCustomerWithKey(
                Guid.NewGuid().ToString(),
                "first",
                "last",
                "debug@debug.com");

            this.BraintreeProviderSettings = TestHelper.GetBraintreeProviderSettings();

            AutoMapperMappings.CreateMappings();

            this.Gateway = this.BraintreeProviderSettings.AsBraintreeGateway();

            this.BraintreeApiService = new BraintreeApiService(this.BraintreeProviderSettings);

        }
    }
}