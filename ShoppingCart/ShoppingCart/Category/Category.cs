using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Category
{
    public abstract class Category
    {
        public abstract string Title { get; }
        public abstract Category ParentCategory { get; set; }
    }
}
