namespace NKart.Web.Discounts.Coupons
{
    using System.Linq;

    using NKart.Core;
    using NKart.Core.Checkout;
    using NKart.Core.Events;
    using NKart.Core.Gateways.Payment;
    using NKart.Core.Sales;
    using NKart.Core.Services;

    using Umbraco.Core;
    using Umbraco.Core.Logging;

    /// <summary>
    /// The coupon redemption event handler.
    /// </summary>
    public class CouponRedemptionEventHandler : ApplicationEventHandler
    {
        /// <summary>
        /// The Umbraco Application Starting event.
        /// </summary>
        /// <param name="umbracoApplication">
        /// The umbraco application.
        /// </param>
        /// <param name="applicationContext">
        /// The application context.
        /// </param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            SalePreparationBase.Finalizing += SalePreparationBaseOnFinalizing;
            CheckoutPaymentManagerBase.Finalizing += CheckoutPaymentManagerBaseOnFinalizing;
        }

        /// <summary>
        /// Records the redemption of a coupon offer.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CheckoutPaymentManagerBaseOnFinalizing(CheckoutPaymentManagerBase sender, CheckoutEventArgs<IPaymentResult> e)
        {
            var invoice = e.Item.Invoice;

            // get the collection of redemptions to be record
            var visitor = new CouponRedemptionLineItemVisitor(invoice.CustomerKey);
            invoice.Items.Accept(visitor);

            if (!visitor.Redemptions.Any()) return;

            if (MerchelloContext.Current != null)
            {
                ((ServiceContext)MerchelloContext.Current.Services).OfferRedeemedService.Save(visitor.Redemptions);
            }
            else
            {
                LogHelper.Debug<CouponRedemptionEventHandler>("MerchelloContext was null.  Could not record coupon redemption.");
            }
        }

        /// <summary>
        /// Records the redemption of a coupon offer.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// TODO RSS - remove when SalePreparation is removed
        private void SalePreparationBaseOnFinalizing(SalePreparationBase sender, SalesPreparationEventArgs<IPaymentResult> e)
        {
            var invoice = e.Entity.Invoice;

            // get the collection of redemptions to be record
            var visitor = new CouponRedemptionLineItemVisitor(invoice.CustomerKey);
            invoice.Items.Accept(visitor);

            if (!visitor.Redemptions.Any()) return;

            if (MerchelloContext.Current != null)
            {
                ((ServiceContext)MerchelloContext.Current.Services).OfferRedeemedService.Save(visitor.Redemptions);
            }
            else
            {
                LogHelper.Debug<CouponRedemptionEventHandler>("MerchelloContext was null.  Could not record coupon redemption.");
            }
        }
    }
}