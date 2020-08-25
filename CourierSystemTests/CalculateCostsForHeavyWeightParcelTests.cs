using CalculateDeliveryCost;
using NUnit.Framework;

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
            DeliveryOption deliveryOption = new DeliveryOption { Box = box, IsSpeedDelivery = false };
            var actualCost = calculateDeliveryCost.GetTotalCost(deliveryOption);

            double expectedCost = 65;
            Assert.AreEqual(expectedCost, actualCost);
        }

        [Test]
        public void CalculateDeliveryCost_WhenHeavyWeightPackageWithSpeedyDeliveryExceedsWeight_ReturnCharges()
        {
            var box = new Box() { Length = 11, Breadth = 101, Height = 7, Weight = 65 };
            DeliveryOption deliveryOption = new DeliveryOption { Box = box, IsSpeedDelivery = true };
            var actualCost = calculateDeliveryCost.GetTotalCost(deliveryOption);

            double expectedCost = 130;
            Assert.AreEqual(expectedCost, actualCost);
        }
    }
}
