using System.Collections.Generic;

namespace CalculateDeliveryCost
{
   public class Receipt
    {
        List<PricePerBox> pricePerBoxes = new List<PricePerBox>();
        public double SpeedDeliveryCharges { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public List<PricePerBox> PricePerBoxes { get => pricePerBoxes; set => pricePerBoxes = value; }
    }
}
