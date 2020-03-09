using Moq;
using ShoppingCart.Cart;
using ShoppingCart.Delivery;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCart.Test.Delivery
{
    public class DeliveryCostCalculatortest
    {
        Mock<IShoppingCart> _shoppingCart;
        DeliveryCostCalculator _deliveryCostCalculator;

        public DeliveryCostCalculatortest()
        {
            _shoppingCart = new Mock<IShoppingCart>();
        }

        [Fact]
        public void CalculateFor_ShouldArgumentNullException_WhenCartIsNull()
        {
            _deliveryCostCalculator = new DeliveryCostCalculator(12, 8, 2.99);
            Assert.Throws<ArgumentNullException>(() => _deliveryCostCalculator.CalculateFor(null));

        }

        [Theory]
        [InlineData(5, 8, 2.99, 36.99)]
        [InlineData(3, 6, 3, 27)]
        public void CalculateFor_ShouldReturnExpectedCorrectDeliveryCalculation_WhenGivenCosts(double costPerDelivery, double costPerProduct, double fixedCost, double expected)
        {
            _deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost);
            _shoppingCart.Setup(p => p.GetNumberOfDeliveries()).Returns(2);
            _shoppingCart.Setup(p => p.GetNumberOfProducts()).Returns(3);
            var result = _deliveryCostCalculator.CalculateFor(_shoppingCart.Object);

            Assert.True(expected == result);

        }
    }
}
