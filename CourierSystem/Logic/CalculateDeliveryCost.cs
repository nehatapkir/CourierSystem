using System.Linq;

namespace CalculateDeliveryCost
{
    public class CalculateDeliveryCost : ICalculateDeliveryCost
    {
        CalculatePricePerBox calculatePricePerBox;
        CalculateDiscounts calculateDiscounts;

        public CalculateDeliveryCost()
        {
            calculatePricePerBox = new CalculatePricePerBox();
            calculateDiscounts = new CalculateDiscounts();
        }

        private double GetCostSpeedDelivery(double initialCost)
        {
            return initialCost * 2;
        }

        public Receipt GetTotalCost(Order order)
        {
            Receipt receipt = new Receipt();

            receipt.PricePerBoxes = calculatePricePerBox.GetPricePerBox(order);
            receipt.TotalPrice = calculateDiscounts.ApplyDiscountIfApplicable(receipt.PricePerBoxes);
            receipt.Discount = receipt.PricePerBoxes.Sum(i => i.Price) - receipt.TotalPrice;
            if (order.IsSpeedDelivery)
            {
                receipt.SpeedDeliveryCharges = receipt.TotalPrice;
                receipt.TotalPrice = GetCostSpeedDelivery(receipt.TotalPrice);
            }
            return receipt;
        }
    }
}
