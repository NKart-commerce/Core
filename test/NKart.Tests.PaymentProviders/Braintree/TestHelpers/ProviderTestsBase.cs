﻿namespace NKart.Tests.PaymentProviders.Braintree.TestHelpers
{
    using NKart.Providers.Payment.Braintree.Provider;

    using NUnit.Framework;

    public abstract class ProviderTestsBase : BraintreeTestBase
    {

        protected BraintreePaymentGatewayProvider Provider;

        
        [TestFixtureSetUp]
        public override void TestFixtureSetup()
        {
            base.TestFixtureSetup();



            // Sets Umbraco SqlSytax and ensure database is setup

        }
    }
}