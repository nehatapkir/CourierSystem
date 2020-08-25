using System.Collections.Generic;

namespace CalculateDeliveryCost
{
     public class Order
    {
         private List<Box> box = new List<Box>();

        public List<Box> Box { get => box; set => box = value; }

        public bool IsSpeedDelivery { get; set; }
        
        public double TotalCost { get; set; }
    }
}
