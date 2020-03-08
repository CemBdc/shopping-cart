using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Campaign
{
    public class AmountCampaign: ICampaign
    {
        private double _campaignValue;
        private int _minProductQuantity;

        public AmountCampaign(double campaignValue, int minProductQuantity)
        {
            _campaignValue = campaignValue;
            _minProductQuantity = minProductQuantity;
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
    }
}
