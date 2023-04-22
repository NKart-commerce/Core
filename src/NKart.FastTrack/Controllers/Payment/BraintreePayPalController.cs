namespace NKart.FastTrack.Controllers.Payment
{
    using System.Web.Mvc;

    using NKart.Core.Gateways;
    using NKart.Web.Store.Models;

    using Umbraco.Core;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// A controller responsible for rendering and processing Braintree PayPal payments.
    /// </summary>
    [PluginController("FastTrack")]
    [GatewayMethodUi("BrainTree.PayPal.OneTime")]
    public class BraintreePayPalController : FastTrackBraintreeControllerBase<BraintreePaymentModel>
    {
       
    }
}