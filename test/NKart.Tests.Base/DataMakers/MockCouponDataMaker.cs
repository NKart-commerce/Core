namespace NKart.Tests.Base.DataMakers
{
    using System;

    using NKart.Core.Models;
    using NKart.Core.Models.Interfaces;
    using NKart.Web.Discounts.Coupons;

    public class MockCouponDataMaker
    {
        public static ICoupon CouponForInserting()
        {
            return new Coupon(new OfferSettings("Test coupon", "test", CouponManager.Instance.Key));

        }
    }
}