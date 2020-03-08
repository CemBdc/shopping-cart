﻿using ShoppingCart.Category;
using ShoppingCart.Product;
using ShoppingCart.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCart.Test.Product
{
    public class ProductTest
    {
        public ShoppingCart.Category.Category electronicCategory;
        public ShoppingCart.Category.Category computerCategory;
        public ShoppingCart.Category.Category phoneCategory;

        public ProductTest()
        {
            CategoryFactory categoryFactory = new CategoryFactory();
            electronicCategory = categoryFactory.Get(CategoryTypes.Electronic);
            computerCategory = categoryFactory.Get(CategoryTypes.Computer, electronicCategory);
            phoneCategory = categoryFactory.Get(CategoryTypes.Phone, electronicCategory);
        }

        [Theory]
        [InlineData("")]
        public void ProductIphone_ShouldArgumentNullException_WhenTitleIsNull(string title)
        {
            var iphone = new Iphone(7500, phoneCategory, title);
            Assert.Throws<ArgumentNullException>(() => iphone.Title);

        }

        [Theory]
        [InlineData("")]
        public void ProductMacbook_ShouldArgumentNullException_WhenTitleIsNull(string title)
        {
            var macbook = new Macbook(18500, computerCategory, title);
            Assert.Throws<ArgumentNullException>(() => macbook.Title);
        }

        [Theory]
        [InlineData(0)]
        public void ProductIphone_ShouldArgumentOutOfRangeException_WhenPriceIsLessThanOrEqualZero(double price)
        {
            var iphone = new Iphone(price, phoneCategory);
            Assert.Throws<ArgumentOutOfRangeException>(() => iphone.Price);

        }

        [Theory]
        [InlineData(0)]
        public void ProductMacbook_ShouldArgumentOutOfRangeException_WhenPriceIsLessThanOrEqualZero(double price)
        {
            var macbook = new Macbook(price, phoneCategory);
            Assert.Throws<ArgumentOutOfRangeException>(() => macbook.Price);

        }
    }
}
