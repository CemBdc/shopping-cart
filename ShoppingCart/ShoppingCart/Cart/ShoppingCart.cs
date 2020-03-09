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
        private Coupon.ICoupon _coupon { get; set; }
        private List<ICampaign> _campaigns { get; set; }

        public ShoppingCart(IDeliveryCostCalculator deliveryCostCalculator)
        {
            _deliveryCostCalculator = deliveryCostCalculator;
            _products = new Dictionary<Product.Product, int>();
            _campaigns = new List<ICampaign>();
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

        public int GetNumberOfDeliveries() => _products is null || _products.Count == 0 ? 0 : GetProductsDistinctCategoriTitles(_products).Count;
        
        public int GetNumberOfProducts() => _products is null ? 0 : _products.Count;

        public double GetTotalAmount() => _products is null || _products.Count == 0 ? 0 : _products.Sum(e => e.Key.Price * e.Value);

        public void ApplyCoupon(ICoupon coupon)
        {
            _coupon = coupon;
        }

        public double GetCouponDiscount()
        {
            var totalPrice = GetTotalAmount();

            double discount = 0;

            if (_coupon != null && _coupon.IsValidCoupon(totalPrice))
                discount = _coupon.Discount(totalPrice);

            return discount;
        }

        public void ApplyDiscounts(ICampaign campaign)
        {
            _campaigns.Add(campaign);
        }

        public double GetCampaignDiscount()
        {
            var totalPrice = GetTotalAmount();
            double discount = 0;

            if (_campaigns is null || _campaigns.Count <= 0)
                return discount;

            var categories = GetProductsCategories(_products);

            foreach (var item in _campaigns)
            {
                var categoryCount = categories.Count(p => p.Title == item.GetCategory().Title);
                if (categoryCount > 0 && item.IsValidCampaign(categoryCount))
                {
                    discount = discount < item.Discount(totalPrice) ? item.Discount(totalPrice) : discount;
                }
            }

            return discount;
        }

        public List<string> GetProductsDistinctCategoriTitles(Dictionary<Product.Product, int> products)
        {
            return GetProductsCategories(products).Select(x => x.Title).Distinct().ToList();
            //List<Category.Category> categories = new List<Category.Category>();

            //Category.Category parentCategory;

            //foreach (var item in products)
            //{
            //    if (categories.Count == 0 || !categories.Any(p => p.Title == item.Key.Category.Title))
            //    {
            //        categories.Add(item.Key.Category);
            //    }

            //    if (item.Key.Category.ParentCategory is null)
            //        continue;

            //    parentCategory = item.Key.Category.ParentCategory;

            //    while (parentCategory != null)
            //    {
            //        if (categories.Count == 0 || !categories.Any(p => p.Title == parentCategory.Title))
            //        {
            //            categories.Add(parentCategory);
            //        }

            //        parentCategory = parentCategory.ParentCategory;
            //    }

            //}

            //return categories;
        }

        public List<Category.Category> GetProductsCategories(Dictionary<Product.Product, int> products)
        {
            List<Category.Category> categories = new List<Category.Category>();

            Category.Category parentCategory;

            foreach (var item in products)
            {
                categories.Add(item.Key.Category);

                if (item.Key.Category.ParentCategory is null)
                    continue;

                parentCategory = item.Key.Category.ParentCategory;

                while (parentCategory != null)
                {
                    categories.Add(parentCategory);

                    parentCategory = parentCategory.ParentCategory;
                }

            }

            return categories;
        }
    }
}
