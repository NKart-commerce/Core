using NKart.FastTrack.Factories;
using NKart.FastTrack.Models;

namespace NKart.FastTrack.Controllers
{
    using System.Web.Mvc;
    using NKart.FastTrack.Factories;
    using NKart.FastTrack.Models;
    using NKart.Web.Controllers;
    using NKart.Web.Factories;
    using NKart.Web.Models.Ui;
    using NKart.Web.Store.Models;

    using Umbraco.Core;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// The default checkout summary controller.
    /// </summary>
    [PluginController("FastTrack")]
    public class CheckoutSummaryController : CheckoutSummaryControllerBase<FastTrackCheckoutSummaryModel, FastTrackBillingAddressModel, StoreAddressModel, StoreLineItemModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutSummaryController"/> class.
        /// </summary>
        public CheckoutSummaryController()
            : base(
                  new FastTrackCheckoutSummaryModelFactory(),
                  new CheckoutContextSettingsFactory())
        {
        }

        /// <summary>
        /// Renders the Basket Summary.
        /// </summary>
        /// <param name="view">
        /// The optional view.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public override ActionResult BasketSummary(string view = "")
        {
            var model = CheckoutSummaryFactory.Create(Basket, CheckoutManager);

            // EDIT ADDRESS BUTTON VISIBILITY
            // FastTrack implementation uses the notion of checkout stages in the UI
            // to determine what to display and the order in which to display them.  We can 
            // determine the stage by validating models at various points
            if (ValidateModel(model.ShippingAddress))
            {
                model.CheckoutStage = CheckoutStage.ShipRateQuote;
            }
            else if (ValidateModel(model.BillingAddress))
            {
                model.CheckoutStage = CheckoutStage.ShippingAddress;
            }
            
            return view.IsNullOrWhiteSpace() ? this.PartialView(model) : this.PartialView(view, model);
        }
    }
}