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

        public Category(string title, Category parentCategory = null)
        {
            _title = title;
            ParentCategory = parentCategory;
        }
        
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
