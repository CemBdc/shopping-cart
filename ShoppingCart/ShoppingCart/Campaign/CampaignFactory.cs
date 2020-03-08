using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Campaign
{
    public class CampaignFactory
    {
        public ICampaign Get(double campaignValue, int minProductQuantity, CampaignTypes campaignTypes)
        {
            ICampaign campaign = null;

            switch (campaignTypes)
            {
                case CampaignTypes.Amount:
                    campaign = new AmountCampaign(campaignValue, minProductQuantity);
                    break;
                case CampaignTypes.Rate:
                    campaign = new RateCampaign(campaignValue, minProductQuantity);
                    break;
            }

            return campaign;
        }
    }
}
