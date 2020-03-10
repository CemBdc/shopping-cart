using Moq;
using ShoppingCart.Cart;
using ShoppingCart.Delivery;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCart.Test.Cart
{

    public class ShoppingCartTest
    {
        Mock<IDeliveryCostCalculator> _deliveryCostCalculator;
        ShoppingCart.Cart.ShoppingCart _shoppingCart;

        public ShoppingCartTest()
        {
            _deliveryCostCalculator = new Mock<IDeliveryCostCalculator>();
        }

        [Fact]
        public void AddItem_ShouldArgumentNullException_WhenProductIsNull()
        {
            _shoppingCart = new ShoppingCart.Cart.ShoppingCart(_deliveryCostCalculator.Object);
            Assert.Throws<ArgumentNullException>(() => _shoppingCart.AddItem(null, 1));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-958)]
        public void AddItem_ShouldArgumentOutOfRangeException_WhenQuantityIsLessThanOrEqualZero(int quantity)
        {
            _shoppingCart = new ShoppingCart.Cart.ShoppingCart(_deliveryCostCalculator.Object);

            ShoppingCart.Product.Iphone iphone = new ShoppingCart.Product.Iphone(1200, new Category.Category("Category1"));

            Assert.Throws<ArgumentOutOfRangeException>(() => _shoppingCart.AddItem(iphone, quantity));

        }

        [Fact]
        public void GetNumberOfDeliveries_ShouldReturnTwo_WhenDistinctCategoryCountIsTwo()
        {
            _shoppingCart = new ShoppingCart.Cart.ShoppingCart(_deliveryCostCalculator.Object);

            ShoppingCart.Product.Iphone iphone1 = new ShoppingCart.Product.Iphone(1200, new Category.Category("c1"));
            ShoppingCart.Product.Iphone iphone2 = new ShoppingCart.Product.Iphone(1200, new Category.Category("c123"));
            ShoppingCart.Product.Iphone iphone3 = new ShoppingCart.Product.Iphone(1200, new Category.Category("c1"));
            ShoppingCart.Product.Iphone iphone4 = new ShoppingCart.Product.Iphone(1200, new Category.Category("c1"));


            _shoppingCart.AddItem(iphone1, 1);
            _shoppingCart.AddItem(iphone2, 1);
            _shoppingCart.AddItem(iphone3, 1);
            _shoppingCart.AddItem(iphone4, 1);

            var numberOfDeliveries = _shoppingCart.GetNumberOfDeliveries();
            Assert.True(numberOfDeliveries == 2);
            

        }

        [Fact]
        public void GetNumberOfProducts_ShouldReturnZero_WhenNoProductAdded()
        {
            _shoppingCart = new ShoppingCart.Cart.ShoppingCart(_deliveryCostCalculator.Object);

            var numberOfProducts = _shoppingCart.GetNumberOfProducts();
            Assert.True(numberOfProducts == 0);


        }

        [Fact]
        public void GetTotalAmount_ShouldReturnZero_WhenNoProductAdded()
        {
            _shoppingCart = new ShoppingCart.Cart.ShoppingCart(_deliveryCostCalculator.Object);

            var totalAmount = _shoppingCart.GetTotalAmount();
            Assert.True(totalAmount == 0);


        }

        [Fact]
        public void GetNumberOfDifferentProducts_ShouldReturnTwo_WhenDistinctProductCountIsTwo()
        {
            _shoppingCart = new ShoppingCart.Cart.ShoppingCart(_deliveryCostCalculator.Object);

            ShoppingCart.Product.Iphone iphone1 = new ShoppingCart.Product.Iphone(1200, new Category.Category("c1"));
            ShoppingCart.Product.Iphone iphone2 = new ShoppingCart.Product.Iphone(1200, new Category.Category("c123"));
            ShoppingCart.Product.Macbook macbook1 = new ShoppingCart.Product.Macbook(1200, new Category.Category("x1"));
            ShoppingCart.Product.Macbook macbook2 = new ShoppingCart.Product.Macbook(1200, new Category.Category("x2"));


            _shoppingCart.AddItem(iphone1, 1);
            _shoppingCart.AddItem(iphone2, 1);
            _shoppingCart.AddItem(macbook1, 1);
            _shoppingCart.AddItem(macbook2, 1);

            var numberOfProducts = _shoppingCart.GetNumberOfDifferentProducts();
            Assert.True(numberOfProducts == 2);


        }
    }
}
