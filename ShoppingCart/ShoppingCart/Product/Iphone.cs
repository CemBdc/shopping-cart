using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Product
{
    public class Iphone: Product
    {
        private readonly string _title;
        private double _price;

        public Iphone()
        {
            _title = "Iphone";
            _price = 10000.0;
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
