using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Category
{
    public class ComputerCategory: Category
    {
        private readonly string _title;
        private Category _parentCategory;

        public ComputerCategory()
        {
            _title = "Computer";
        }

        public ComputerCategory(Category parentCategory)
        {
            _title = "Computer";
            _parentCategory = parentCategory;
        }

        public override string Title
        {
            get { return _title; }
        }
    }
}
