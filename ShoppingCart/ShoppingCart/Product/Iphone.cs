using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Product
{
    public class Iphone: Product
    {
        public Iphone(double price, ShoppingCart.Category.Category category, string title = "Iphone"):base(title, price, category)
        {
        }
        
    }
}
