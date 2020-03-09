using ShoppingCart.Category;
using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Product;
using ShoppingCart.Campaign;
using ShoppingCart.Coupon;
using Microsoft.Extensions.Configuration;

namespace ShoppingCart
{
    /// <summary>
    /// The App.cs class that will be used to run the application and will contain all of the running console application code.
    /// </summary>
    class App
    {
        private readonly IConfiguration _config;

        public App(IConfiguration config)
        {
            _config = config;
        }

        public void Run()
        {
            var costPerDelivery = _config.GetValue<string>("Delivery:CostPerDelivery");
            var costPerProduct = _config.GetValue<string>("Delivery:CostPerProduct");
            var fixedCost = _config.GetValue<string>("Delivery:FixedCost");
            
            Console.WriteLine("CostPerDelivery: " + costPerDelivery);
            Console.WriteLine("CostPerProduct: " + costPerProduct);
            Console.WriteLine("FixedCost: " + fixedCost);

            var electronicCategory = new Category.Category("Electronic");
            var computerCategory = new Category.Category("Computer", electronicCategory);
            var phoneCategory = new Category.Category("Phone", electronicCategory);

            var ipone = new Iphone(7500, phoneCategory);
            var macbook = new Macbook(18500, computerCategory);

            CampaignFactory campaignFactory = new CampaignFactory();
            var campaign1 = campaignFactory.Get(electronicCategory, 20, 3, CampaignTypes.Rate);
            var campaign2 = campaignFactory.Get(computerCategory, 5, 5, CampaignTypes.Amount);
            var campaign3 = campaignFactory.Get(phoneCategory, 50, 5, CampaignTypes.Rate);

            CouponFactory couponFactory = new CouponFactory();
            var coupon1 = couponFactory.Get(100, 10, CouponTypes.Rate);
            var coupon2 = couponFactory.Get(500, 150, CouponTypes.Amount);

            Console.WriteLine(ipone.Title + " " + ipone.Price + " " + ipone.Category.ParentCategory.Title + " " + ipone.Category.Title);
            Console.WriteLine(macbook.Title + " " + macbook.Price + " " + macbook.Category.ParentCategory.Title + " " + macbook.Category.Title);
            Console.ReadLine();

        }
    }
}
