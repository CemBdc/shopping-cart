using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Product
{
    public abstract class Product
    {
        public abstract string Title { get; }
        public abstract double Price { get; set; }
        public abstract ShoppingCart.Category.Category Category { get; set; }
    }
}
