﻿namespace NKart.FastTrack.Controllers.Payment
{
    using System.Web.Mvc;

    using NKart.Core.Gateways;
    using NKart.Web.Store.Models;

    using Umbraco.Core;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// A controller responsible for rendering and processing Braintree CC payments.
    /// </summary>
    [PluginController("FastTrack")]
    [GatewayMethodUi("BrainTree.StandardTransaction")]
    public class BraintreeStandardCcController : FastTrackBraintreeControllerBase<BraintreePaymentModel>
    {
        ///// <summary>
        ///// Responsible for rendering the BrainTree PayPal payment form.
        ///// </summary>
        ///// <param name="view">
        ///// The optional view.
        ///// </param>
        ///// <returns>
        ///// The <see cref="ActionResult"/>.
        ///// </returns>
        //[ChildActionOnly]
        //[GatewayMethodUi("BrainTree.StandardTransaction")]
        //public override ActionResult PaymentForm(string view = "")
        //{
        //    var paymentMethod = this.CheckoutManager.Payment.GetPaymentMethod();
        //    var billing = this.CheckoutManager.Customer.GetBillToAddress();
        //    if (paymentMethod == null) return this.InvalidCheckoutStagePartial();

        //    var model = this.CheckoutPaymentModelFactory.Create(CurrentCustomer, paymentMethod);
        //    model.PostalCode = billing.PostalCode;

        //    return view.IsNullOrWhiteSpace() ? this.PartialView(model) : this.PartialView(view, model);
        //}
    }
}