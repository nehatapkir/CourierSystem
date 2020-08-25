using CalculateDeliveryCost;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class CalculateDeliveryCostForOrderWithDiscountTest
    {
        ICalculateDeliveryCost calculateDeliveryCost;

        [SetUp]
        public void Setup() => calculateDeliveryCost = new CalculateDeliveryCost.CalculateDeliveryCost();

        #region phase5
        [Test]
        public void CalculateDeliveryCost_WhenSmallParcelMania_ApplyDiscount()
        {
            var box = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 2 };
            var box1 = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 2 };
            var box2 = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 4 };
            var box3 = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 6 };
            var boxes = new List<Box> { box, box1, box2, box3 };
            Order order = new Order { Box = boxes, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 27;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenSmallParcelManiaSpeedyDelivery_ApplyDiscount()
        {
            var box = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 2 };
            var box1 = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 2 };
            var box2 = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 4 };
            var box3 = new Box() { Length = 9, Breadth = 8, Height = 7, Weight = 6 };
            var boxes = new List<Box> { box, box1, box2, box3 };
            Order order = new Order { Box = boxes, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 54;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenMediumParcelMania_ApplyDiscount()
        {
            var box = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 4 };
            var box1 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 5 };
            var box2 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 6 };
            var box3 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 7 };
            var box4 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 3 };
            var box5 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 7 };
            var boxes = new List<Box> { box, box1, box2, box3, box4, box5 };
            Order order = new Order { Box = boxes, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 54;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenMediumParcelManiaSpeedyDelivery_ApplyDiscount()
        {
            var box = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 4 };
            var box1 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 5 };
            var box2 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 6 };
            var box3 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 7 };
            var box4 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 3 };
            var box5 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 7 };
            var boxes = new List<Box> { box, box1, box2, box3, box4, box5 };
            Order order = new Order { Box = boxes, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 108;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenMixedParcelMania_ApplyDiscount()
        {
            var box = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 4 };
            var box1 = new Box() { Length = 11, Breadth = 51, Height = 7, Weight = 5 };
            var box2 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 6 };
            var box3 = new Box() { Length = 11, Breadth = 110, Height = 7, Weight = 7 };
            var box4 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 3 };
            var box5 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 7 };
            var boxes = new List<Box> { box, box1, box2, box3, box4, box5 };
            Order order = new Order { Box = boxes, IsSpeedDelivery = false };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 88;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }

        [Test]
        public void CalculateDeliveryCost_WhenMixedParcelManiaSpeedyDelivery_ApplyDiscount()
        {
            var box = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 4 };
            var box1 = new Box() { Length = 11, Breadth = 51, Height = 7, Weight = 5 };
            var box2 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 6 };
            var box3 = new Box() { Length = 11, Breadth = 110, Height = 7, Weight = 7 };
            var box4 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 3 };
            var box5 = new Box() { Length = 11, Breadth = 10, Height = 7, Weight = 7 };
            var boxes = new List<Box> { box, box1, box2, box3, box4, box5 };
            Order order = new Order { Box = boxes, IsSpeedDelivery = true };
            var receipt = calculateDeliveryCost.GetTotalCost(order);

            double expectedCost = 176;
            Assert.AreEqual(expectedCost, receipt.TotalPrice);
        }
        #endregion
    }
}
