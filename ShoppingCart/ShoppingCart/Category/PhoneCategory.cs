using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Category
{
    public class PhoneCategory: Category
    {
        private readonly string _title;
        private Category _parentCategory;

        public PhoneCategory()
        {
            _title = "Phone";
        }

        public PhoneCategory(Category parentCategory)
        {
            _title = "Phone";
            _parentCategory = parentCategory;
        }

        public override string Title
        {
            get { return _title; }
        }
    }
}
