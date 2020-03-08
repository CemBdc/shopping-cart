using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Coupon
{
    public interface ICoupon
    {
        bool IsValidCampaign(int quantity);
        double Discount(double amount);
    }
}
