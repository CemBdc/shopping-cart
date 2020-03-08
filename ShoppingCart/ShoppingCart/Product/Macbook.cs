using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Product
{
    public class Macbook: Product
    {
        private readonly string _title;
        private double _price;
        private ShoppingCart.Category.Category _category;
        
        public Macbook(double price, ShoppingCart.Category.Category category, string title = "Macbook")
        {
            _title = title;
            _price = price;
            _category = category;
        }

        public override string Title
        {
            get { return _title; }
        }

        public override double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public override ShoppingCart.Category.Category Category
        {
            get { return _category; }
            set { _category = value; }
        }
    }
}
