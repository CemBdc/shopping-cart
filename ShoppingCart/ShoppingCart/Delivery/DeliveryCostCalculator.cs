using ShoppingCart.Cart;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Delivery
{
    public class DeliveryCostCalculator: IDeliveryCostCalculator
    {
        private double _costPerDelivery { get; set; }
        private double _costPerProduct { get; set; }
        private double _fixedCost { get; set; }

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            _costPerDelivery = costPerDelivery;
            _costPerProduct = costPerProduct;
            _fixedCost = fixedCost;
        }

        public double CalculateFor(IShoppingCart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException();
            }

            var numberOfDeliveries = cart.GetNumberOfDeliveries();
            var numberOfProducts = cart.GetNumberOfProducts();
            return (_costPerDelivery * numberOfDeliveries) + (_costPerProduct * numberOfProducts) + _fixedCost;
        }
    }
}
