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

        public RateCampaign(double campaignValue, int minProductQuantity)
        {
            _campaignValue = campaignValue;
            _minProductQuantity = minProductQuantity;
        }

        //public List<Campaign> Campaigns { get; set; }

        //public void AddCampaign(Campaign campaign)
        //{
        //    if (Campaigns == null)
        //        Campaigns = new List<Campaign>();

        //    var existCampaign = Campaigns.Any(p => p.Category.Title == campaign.Category.Title && 
        //                                            p.DiscountValue == campaign.DiscountValue && 
        //                                            p.ProductQuantity == campaign.ProductQuantity);

        //    if (existCampaign)
        //        throw new NotSupportedException("There is already campaign defined with same parameters");
        //    if (!CampaignHelper.CampaginParametersIsValid(campaign))
        //        throw new Exception("Invalid parameters for campaign");

        //    Campaigns.Add(campaign);

        //}

        //public double GetCategoryMaximumDiscount(ShoppingCart.Category.Category category)
        //{
        //    double maxDiscount = 0;

        //    if (category != null && string.IsNullOrWhiteSpace(category.Title))
        //    {
        //        var categoryCampaigns = Campaigns.Where(p => p.Category.Title == category.Title).ToList();

        //        if (categoryCampaigns == null || categoryCampaigns.Count <= 0)
        //            return maxDiscount;

        //        for (int i = 0; i < categoryCampaigns.Count; i++)
        //        {
        //            //totalAmount * (rate * 0.01);
        //        }
        //    }
        //}

        public double Discount(double amount)
        {
            double discount = 0;

            if (amount <= 0)
                return discount;

            return amount * (_campaignValue * 0.01);
        }

        public bool IsValidCampaign(int quantity)
        {
            return quantity >= _minProductQuantity;
        }
    }
}
