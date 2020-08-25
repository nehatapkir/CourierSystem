using System.Collections.Generic;
using System.Linq;

namespace CalculateDeliveryCost
{
    class SmallParcelManiaDiscount : ICalculateDiscounts
    {
        public double GetOffer(List<PricePerBox> boxes)
        {
            var list = PackageDetailsUtil.SplitList(boxes, 4);
            double totalPrice = 0;
            foreach (var item in list)
            {
                if(item.Count == 4)
                totalPrice = totalPrice + item[0].Price + item[1].Price + item[2].Price;
                else
                {
                    foreach(var box in item)
                    {
                        totalPrice = totalPrice + box.Price;
                    }
                }                    
            }
            return totalPrice;
        }
    }
}
