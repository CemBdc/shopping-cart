using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Product
{
    public class Macbook: Product
    {
        private readonly string _title;
        private double _price;

        public Macbook()
        {
            _title = "Macbook";
            _price = 15500.0;
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
    }
}
