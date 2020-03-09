using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Campaign
{
    public class CampaignFactory
    {
        public ICampaign Get(Category.Category category, double campaignValue, int minProductQuantity, CampaignTypes campaignTypes)
        {
            ICampaign campaign = null;

            switch (campaignTypes)
            {
                case CampaignTypes.Amount:
                    campaign = new AmountCampaign(category, campaignValue, minProductQuantity);
                    break;
                case CampaignTypes.Rate:
                    campaign = new RateCampaign(category, campaignValue, minProductQuantity);
                    break;
            }

            return campaign;
        }
    }
}
