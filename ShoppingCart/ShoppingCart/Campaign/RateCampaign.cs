using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Category;
using System.Linq;
using System.Linq.Expressions;
using ShoppingCart.Utils.Helper;

namespace ShoppingCart.Campaign
{
    public class RateCampaign: ICampaign
    {
        private double _campaignValue;
        private int _minProductQuantity;
        private Category.Category _category;

        public RateCampaign(Category.Category category, double campaignValue, int minProductQuantity)
        {
            _campaignValue = campaignValue;
            _minProductQuantity = minProductQuantity;
            _category = category;
        }

        public double Discount(double amount)
        {
            double discount = 0;

            if (amount <= 0)
                return discount;

            return amount * (_campaignValue * 0.01);
        }

        public Category.Category GetCategory()
        {
            return _category;
        }

        public bool IsValidCampaign(int quantity)
        {
            return quantity >= _minProductQuantity;
        }
    }
}
