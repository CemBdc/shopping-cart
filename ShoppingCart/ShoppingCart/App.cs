using ShoppingCart.Category;
using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Product;
using ShoppingCart.Campaign;
using ShoppingCart.Coupon;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Cart;
using ShoppingCart.Delivery;

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
            #region Get Delivery cost values from config.

            var costPerDelivery = _config.GetValue<double>("Delivery:CostPerDelivery");
            var costPerProduct = _config.GetValue<double>("Delivery:CostPerProduct");
            var fixedCost = _config.GetValue<double>("Delivery:FixedCost");

            #endregion

            #region Category and product creation

            var computerCategory = new Category.Category("Computer");
            var phoneCategory = new Category.Category("Phone");

            var ipone = new Iphone(7500, phoneCategory);
            var macbook = new Macbook(18500, computerCategory);

            #endregion

            #region Shopping cart creation

            IShoppingCart cart = new Cart.ShoppingCart(new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost));
            cart.AddItem(ipone, 10);
            cart.AddItem(macbook, 5); 

            #endregion

            #region Get campaign type from CampaignFactory with CampaignTypes enum.

            CampaignFactory campaignFactory = new CampaignFactory();
            var campaign2 = campaignFactory.Get(computerCategory, 1500, 1, CampaignTypes.Amount);
            var campaign3 = campaignFactory.Get(phoneCategory, 2, 1, CampaignTypes.Rate);

            #endregion

            #region Apply first campaign discount then coupon

            cart.ApplyDiscounts(campaign2, campaign3);

            CouponFactory couponFactory = new CouponFactory();
            var coupon = couponFactory.Get(500, 150, CouponTypes.Amount);

            cart.ApplyCoupon(coupon); 

            #endregion

            Console.WriteLine(cart.Print());
            
            Console.ReadLine();

        }
    }
}
