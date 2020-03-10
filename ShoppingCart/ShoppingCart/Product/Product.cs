using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Product
{
    public abstract class Product
    {
        private string _title;
        private double _price;
        private ShoppingCart.Category.Category _category;

        public Product(string title, double price, ShoppingCart.Category.Category category)
        {
            _title = title;
            _price = price;
            _category = category;
        }

        public string ProductTitle
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_title))
                {
                    throw new ArgumentNullException();
                }

                return _title;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(_title))
                {
                    throw new ArgumentNullException();
                }

                _title = value;
            }
        }

        public double Price
        {
            get
            {
                if (_price <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _price = value;
            }
        }

        public ShoppingCart.Category.Category Category { get { return _category; } set { _category = value; } }
        
    }
}
