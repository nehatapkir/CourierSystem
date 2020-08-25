using CalculateDeliveryCost;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class CalculateCostsForHeavyWeightParcelTests
    {
        ICalculateDeliveryCost calculateDeliveryCost;

        [SetUp]
        public void Setup() => calculateDeliveryCost = new CalculateDeliveryCost.CalculateDeliveryCost();

        [Test]
        public void CalculateDeliveryCost_WhenHeavyWeightPackageExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 101, Height = 7, Weight = 65 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 65;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenHeavyWeightPackageWithSpeedyDeliveryExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 101, Height = 7, Weight = 65 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 130;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }
    }
}
