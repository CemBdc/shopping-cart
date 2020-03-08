using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Coupon
{
    public class AmountCoupon: ICoupon
    {
        private double _couponValue;
        private int _minProductQuantity;

        public AmountCoupon(double couponValue, int minProductQuantity)
        {
            _couponValue = couponValue;
            _minProductQuantity = minProductQuantity;
        }

        public double Discount(double amount)
        {
            double discount = 0;

            if (amount <= 0)
                return discount;

            return _couponValue;
        }

        public bool IsValidCampaign(int quantity)
        {
            return quantity >= _minProductQuantity;
        }
    }
}
