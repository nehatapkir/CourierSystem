using CalculateDeliveryCost;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    class CalculateWeightOverageCostTests
    {
        ICalculateDeliveryCost calculateDeliveryCost;

        [SetUp]
        public void Setup() => calculateDeliveryCost = new CalculateDeliveryCost.CalculateDeliveryCost();

        [Test]
        public void CalculateDeliveryCost_WhenSmallPackageExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 1.2 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 3.4;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenSmallPackageWithSpeedyDeliveryExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 1.2 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 6.8;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenMediumPackageExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 3.3 };
            
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 8.6;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenMediumPackageWithSpeedyDeliveryExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 3.3 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 17.2;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenLargePackageExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 51, Height = 7, Weight = 6.1 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 15.2;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenLargePackageWithSpeedyDeliveryExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 51, Height = 7, Weight = 6.1 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 30.4;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }


        [Test]
        public void CalculateDeliveryCost_WhenXLPackageExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 101, Height = 7, Weight = 11 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 27;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenXLPackageWithSpeedyDeliveryExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 101, Height = 7, Weight = 11 };
         
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 54;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }
    }
}
