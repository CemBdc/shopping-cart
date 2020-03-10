using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Coupon
{
    public class CouponFactory
    {
        public ICoupon Get(double minCartAmount, double campaignValue, CouponTypes campaignTypes)
        {
            ICoupon coupon = null;

            switch (campaignTypes)
            {
                case CouponTypes.Amount:
                    coupon = new AmountCoupon(campaignValue, minCartAmount);
                    break;
                case CouponTypes.Rate:
                    coupon = new RateCoupon(campaignValue, minCartAmount);
                    break;
            }

            return coupon;
        }
    }
}
