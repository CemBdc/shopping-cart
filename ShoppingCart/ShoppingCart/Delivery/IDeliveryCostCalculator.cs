using ShoppingCart.Cart;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Delivery
{
    public interface IDeliveryCostCalculator
    {
        double CalculateFor(IShoppingCart cart);
    }
}
