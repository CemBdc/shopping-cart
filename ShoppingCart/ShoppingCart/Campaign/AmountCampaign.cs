using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Campaign
{
    public class AmountCampaign: ICampaign
    {
        private double _campaignValue;
        private int _minProductQuantity;
        private Category.Category _category;

        public AmountCampaign(Category.Category category, double campaignValue, int minProductQuantity)
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

            return _campaignValue;
        }

        public bool IsValidCampaign(int quantity)
        {
            return quantity >= _minProductQuantity;
        }

        public Category.Category GetCategory()
        {
            return _category;
        }
    }
}
