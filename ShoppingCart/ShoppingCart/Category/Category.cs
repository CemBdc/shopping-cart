using ShoppingCart.Campaign;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Category
{
    public class Category
    {
        private string _title;
        private Category _parentCategory;
        private List<ICampaign> _campaigns;

        public Category(string title, Category parentCategory = null)
        {
            _title = title;
            ParentCategory = parentCategory;
        }

        //public void AddCampaign(ICampaign campaign)
        //{
        //    if (_campaigns == null)
        //        _campaigns = new List<ICampaign>();

        //    _campaigns.Add(campaign);
        //}

        public List<ICampaign> GetCampaigns() => _campaigns;

        public string Title
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_title))
                {
                    throw new ArgumentNullException();
                }

                return _title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(_title))
                {
                    throw new ArgumentNullException();
                }

                _title = value;
            }
        }

        public Category ParentCategory
        {
            get { return _parentCategory; }
            set { _parentCategory = value; }
        }
    }
}
