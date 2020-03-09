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
    }
}
