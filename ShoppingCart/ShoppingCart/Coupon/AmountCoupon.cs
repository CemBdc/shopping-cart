﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Coupon
{
    public class AmountCoupon: ICoupon
    {
        private double _couponValue;
        private double _minCartAmount;

        public AmountCoupon(double minCartAmount, double couponValue)
        {
            _couponValue = couponValue;
            _minCartAmount = minCartAmount;
        }

        public double Discount(double amount)
        {
            double discount = 0;

            if (amount <= 0)
                return discount;

            return _couponValue;
        }

        public bool IsValidCoupon(double amount)
        {
            return amount >= _minCartAmount;
        }
    }
}
