namespace NKart.Web.Discounts.Coupons
{
    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;

    /// <summary>
    /// Marker interface for the CouponRedemptionResult.
    /// </summary>
    public interface ICouponRedemptionResult : IOfferRedemptionResult<ILineItem>
    {
        /// <summary>
        /// Gets the coupon.
        /// </summary>
        ICoupon Coupon { get;  }
    }
}