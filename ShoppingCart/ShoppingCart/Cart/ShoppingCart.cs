﻿using System;
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

        public int GetNumberOfDeliveries() => _products is null || _products.Count == 0 ? 0 : GetProductsDistinctCategoryCount();
        
        public int GetNumberOfProducts() => _products is null ? 0 : GetNumberOfDifferentProducts();

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

        public void ApplyDiscounts(params ICampaign[] campaign)
        {
            _campaigns.AddRange(campaign);
        }

        public double GetCampaignDiscount()
        {
            var totalPrice = GetTotalAmount();
            double discount = 0;

            if (_campaigns is null || _campaigns.Count <= 0)
                return discount;

            var categories = GetProductsCategories();

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

        public List<string> GetProductsDistinctCategoryTitles()
        {
            return GetProductsCategories().Select(x => x.Title).Distinct().ToList();
        }

        public List<Category.Category> GetProductsCategories()
        {
            List<Category.Category> categories = new List<Category.Category>();

            Category.Category parentCategory;

            foreach (var item in _products)
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

        public double GetTotalAmountAfterDiscounts()
        {
            return (GetTotalAmount() - GetCampaignDiscount()) - GetCouponDiscount();
        }

        public int GetProductsDistinctCategoryCount()
        {
            return GetProductsDistinctCategoryTitles().Count;
        }

        public int GetNumberOfDifferentProducts()
        {
            return _products.GroupBy(p => p.Key.ProductTitle).Count();
        }

        public double GetDeliveryCost() => _deliveryCostCalculator.CalculateFor(this);

        public dynamic GetPrintData()
        {
            return _products.GroupBy(g => new
            {
                g.Key.Category.Title,
                g.Key.ProductTitle,
                g.Value,
                g.Key.Price
            }).Select(s => new
            {
                CategoryName = s.Key.Title,
                ProductTitle = s.Key.ProductTitle,
                Quantity = s.Key.Value,
                Price = s.Key.Price
            }).ToList();
        }

        public string Print()
        {
            var products = GetPrintData();

            StringBuilder builder = new StringBuilder();
            
            builder.AppendLine($"{"Category Name",20}  {"Product Name",20}  {"Quantity",20}  {"Unit Price",20}  {"Total Price",20}");
            builder.AppendLine($"{"_____________",20}  {"____________",20}  {"________",20}  {"__________",20}  {"___________",20}");

            foreach (var item in products)
            {
                builder.AppendLine($"{item.CategoryName,20} {item.ProductTitle,20} {item.Quantity,20} {item.Price,20} {item.Quantity*item.Price,20}\t");
            }
            
            builder.AppendLine($"\nTotal Amount: {GetTotalAmount()}\nTotal Amount After Discounts: {GetTotalAmountAfterDiscounts()}" +
                $"\nTotal Discount: {GetTotalAmount() - GetTotalAmountAfterDiscounts()}\nDelivery Cost: {GetDeliveryCost()}");
            return builder.ToString();
        }
    }
}
