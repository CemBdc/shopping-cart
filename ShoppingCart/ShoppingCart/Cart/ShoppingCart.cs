using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCart.Campaign;
using ShoppingCart.Coupon;
using ShoppingCart.Delivery;

namespace ShoppingCart.Cart
{
    public class ShoppingCart: IShoppingCart
    {
        private IDeliveryCostCalculator _deliveryCostCalculator { get; set; }
        private Dictionary<Product.Product, int> _products { get; set; }

        public ShoppingCart(IDeliveryCostCalculator deliveryCostCalculator)
        {
            _deliveryCostCalculator = deliveryCostCalculator;
            _products = new Dictionary<Product.Product, int>();
        }

        public void AddItem(Product.Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException("Product is null");
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity must be greater than 0");
            if (_products.ContainsKey(product))
            {
                _products[product] += quantity;
                return;
            }

            _products.Add(product, quantity);
        }

        public int GetNumberOfDeliveries() => _products is null || _products.Count == 0 ? 0 : _products.GroupBy(p => p.Key.Category.Title).Count();
        
        public int GetNumberOfProducts() => _products is null ? 0 : _products.Count;


    }
}
