using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Campaign
{
    public interface ICampaign
    {
        bool IsValidCampaign(int quantity);
        double Discount(double amount);
    }
}
