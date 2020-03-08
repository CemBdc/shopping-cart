using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Category
{
    public class ComputerCategory: Category
    {
        private readonly string _title;
        private Category _parentCategory;
        
        public ComputerCategory(Category parentCategory = null)
        {
            _title = "Computer";
            _parentCategory = parentCategory;
        }

        public override string Title
        {
            get { return _title; }
        }

        public override Category ParentCategory
        {
            get { return _parentCategory; }
            set { _parentCategory = value; }
        }
    }
}
