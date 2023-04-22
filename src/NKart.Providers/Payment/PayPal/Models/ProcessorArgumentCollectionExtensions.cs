namespace NKart.Providers.Payment.PayPal.Models
{
    using NKart.Core.Gateways.Payment;
    using NKart.Core.Models;

    public static class ProcessorArgumentCollectionExtensions
    {
        public static void SetPayPalExpressAjaxRequest(this ProcessorArgumentCollection args, bool value)
        {
            args.Add("paypalExpressAjax", value.ToString());
        }

        public static bool GetPayPalRequestIsAjaxRequest(this ExtendedDataCollection extendedData)
        {
            bool value;
            if (bool.TryParse(extendedData.GetValue("paypalExpressAjax"), out value))
            {
                return value;
            }
            else
            {
                return false;
            }
        }
    }
}