using CalculateDeliveryCost;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class CalculateDeliveryCostTest
    {
        ICalculateDeliveryCost calculateDeliveryCost;

        [SetUp]
        public void Setup() => calculateDeliveryCost = new CalculateDeliveryCost.CalculateDeliveryCost();

        [Test]
        public void CalculateDeliveryCost_WhenDimesionLessThan10cm_ReturnSmallPackageChargeS()
        {
            var box = new Box() {Breadth= 9, Height= 5, Length= 7 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);
            double expectedCost = 3;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenDimesionLessThan50cm_ReturnMediumPackageCharges()
        {
            var box = new Box() { Breadth = 11, Height = 49, Length = 7 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 8;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenDimesionLessThan100cm_ReturnLargePackageChargeS()
        {
            var box = new Box() { Breadth = 99, Height = 51, Length = 7 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 15;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenDimesionGreaterThan100cm_ReturnXLPackageChargeS()
        {
            var box = new Box() { Breadth = 101, Height = 51, Length = 7 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 25;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenDimesionLessThanorEqual0cm_Return0ChargeS()
        {
            var box = new Box() { Breadth = 0, Height = -1, Length = 7 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 0;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenDimensionEqualto10_ReturnMediumPackageChargeS()
        {
            var box = new Box() { Breadth = 10, Height = 10, Length = 10 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 8;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenDimensionEqualto50_ReturnLargePackageChargeS()
        {
            var box = new Box() { Breadth = 10, Height = 50, Length = 10 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 15;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenDimensionEqualto100_ReturnXLPackageChargeS()
        {
            var box = new Box() { Breadth = 50, Height = 100, Length = 10 };
            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = false };

            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 25;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }


        [Test]
        public void CalculateDeliveryCost_WhenSmallPackageSpeedyDelivery_ReturnDoubleCharges()
        {
            var box = new Box() { Length = 9, Breadth = 8, Height = 7 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 6;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }


        [Test]
        public void CalculateDeliveryCost_WhenMediumPackageSpeedyDelivery_ReturnDoubleCharges()
        {
            var box = new Box() { Length = 11, Breadth = 10, Height = 7 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 16;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenLargePackageSpeedyDelivery_ReturnDoubleCharges()
        {
            var box = new Box() { Length = 11, Breadth = 51, Height = 7 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 30;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenXLPackageSpeedyDelivery_ReturnDoubleCharges()
        {
            var box = new Box() { Length = 11, Breadth = 101, Height = 7 };

            Order order = new Order { Box = new List<Box> { box }, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 50;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

    
    }
}