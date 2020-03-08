using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Coupon
{
    public class CouponFactory
    {
        public ICoupon Get(double campaignValue, int minProductQuantity, CouponTypes campaignTypes)
        {
            ICoupon coupon = null;

            switch (campaignTypes)
            {
                case CouponTypes.Amount:
                    coupon = new AmountCoupon(campaignValue, minProductQuantity);
                    break;
                case CouponTypes.Rate:
                    coupon = new RateCoupon(campaignValue, minProductQuantity);
                    break;
            }

            return coupon;
        }
    }
}
