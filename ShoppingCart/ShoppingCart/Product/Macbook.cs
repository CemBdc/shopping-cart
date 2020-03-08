using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Product
{
    public class Macbook: Product
    {
        public Macbook(double price, ShoppingCart.Category.Category category, string title = "Macbook") : base(title, price, category)
        {
        }
        
    }
}
