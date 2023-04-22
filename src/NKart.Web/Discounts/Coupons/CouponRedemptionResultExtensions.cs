namespace NKart.Web.Discounts.Coupons
{
    using System;

    using NKart.Core.Marketing.Offer;
    using NKart.Core.Models;

    using Umbraco.Core;

    /// <summary>
    /// The coupon redemption result extensions.
    /// </summary>
    public static class CouponRedemptionResultExtensions
    {
        /// <summary>
        /// Maps an <see cref="IOfferResult{TConstraint,TAward}"/> to <see cref="ICouponRedemptionResult"/>
        /// </summary>
        /// <param name="attempt">
        /// The attempt.
        /// </param>
        /// <param name="coupon">
        /// The coupon.
        /// </param>
        /// <returns>
        /// The <see cref="ICouponRedemptionResult"/>.
        /// </returns>
        public static ICouponRedemptionResult AsCouponRedemptionResult(this Attempt<IOfferResult<ILineItemContainer, ILineItem>> attempt, ICoupon coupon = null)
        {
            var result = attempt.Success
                             ? new CouponRedemptionResult(attempt.Result.Award, attempt.Result.Messages)
                             : new CouponRedemptionResult(
                                   attempt.Exception,
                                   attempt.Result != null ? attempt.Result.Messages : null);
            result.Coupon = coupon;
            return result;
        }  
    }
}