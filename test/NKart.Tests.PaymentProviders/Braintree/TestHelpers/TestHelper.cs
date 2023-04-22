namespace NKart.Tests.PaymentProviders.Braintree.TestHelpers
{
    using System;

    using NKart.Providers.Models;
    using NKart.Providers.Payment.Braintree.Models;
    using NKart.Providers.Payment.Models;

    using Newtonsoft.Json;

    public class TestHelper
    {
        public static BraintreeProviderSettings GetBraintreeProviderSettings()
        {
            var jsonFile = string.Format("{0}\\{1}", Environment.CurrentDirectory, "..\\..\\Braintree\\extendedData.json");
            string json = System.IO.File.ReadAllText(jsonFile);
            return JsonConvert.DeserializeObject<BraintreeProviderSettings>(json);
        }

        public static string PaymentMethodNonce
        {
            get
            {
                return "nonce-from-the-client";
            }
        }

        public static string PaymentMethodToken
        {
            get { return "the_token"; }
        }
    }
}