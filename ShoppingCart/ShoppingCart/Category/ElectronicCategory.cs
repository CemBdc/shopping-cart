using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Category
{
    public class ElectronicCategory: Category
    {
        private readonly string _title;
        private Category _parentCategory;

        public ElectronicCategory()
        {
            _title = "Electronic";
        }

        public ElectronicCategory(Category parentCategory)
        {
            _title = "Electronic";
            _parentCategory = parentCategory;
        }

        public override string Title
        {
            get { return _title; }
        }
    }
}
