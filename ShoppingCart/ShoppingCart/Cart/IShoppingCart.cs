using ShoppingCart.Campaign;
using ShoppingCart.Coupon;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Cart
{
    public interface IShoppingCart
    {
        void AddItem(Product.Product product, int quantity);
        int GetNumberOfDeliveries();
        int GetNumberOfProducts();
        void ApplyCoupon(ICoupon coupon);
        double GetCouponDiscount();
        void ApplyDiscounts(params ICampaign[] campaigns);
        double GetCampaignDiscount();
        double GetTotalAmountAfterDiscounts();
        double GetDeliveryCost();
        string Print();
    }
}
