using ShoppingCart.Campaign;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCart.Test.Campaign
{
    public class CampaignTest
    {
        CampaignFactory campaignFactory;
        Category.Category electronicCategory;

        public CampaignTest()
        {
            campaignFactory = new CampaignFactory();
            electronicCategory = new Category.Category("Electronic");
        }

        [Theory]
        [InlineData(0)]
        public void AmountCampaign_ShouldReturnZero_WhenAmountIsLessThanOrEqualZero(double amount)
        {
            var amountCampaign = campaignFactory.Get(electronicCategory, 20, 3, Utils.Enums.CampaignTypes.Amount);
            var result = amountCampaign.Discount(amount);
            Assert.True(result == 0);

        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(7, 8)]
        public void AmountCampaign_ShouldReturnFalse_WhenMinProductQuantityIsLessThanCampaignQuantity(int quantity, int minProductQuantity)
        {
            var amountCampaign = campaignFactory.Get(electronicCategory, 20, minProductQuantity, Utils.Enums.CampaignTypes.Amount);
            var result = amountCampaign.IsValidCampaign(quantity);
            Assert.False(result);

        }

        [Theory]
        [InlineData(0)]
        public void RateCampaign_ShouldReturnZero_WhenAmountIsLessThanOrEqualZero(double amount)
        {
            var rateCampaign = campaignFactory.Get(electronicCategory, 20, 3, Utils.Enums.CampaignTypes.Rate);
            var result = rateCampaign.Discount(amount);
            Assert.True(result == 0);

        }

        [Theory]
        [InlineData(12, 13)]
        [InlineData(0, 1)]
        public void RateCampaign_ShouldReturnFalse_WhenMinProductQuantityIsLessThanCampaignQuantity(int quantity, int minProductQuantity)
        {
            var rateCampaign = campaignFactory.Get(electronicCategory, 20, minProductQuantity, Utils.Enums.CampaignTypes.Rate);
            var result = rateCampaign.IsValidCampaign(quantity);
            Assert.False(result);

        }
    }
}
