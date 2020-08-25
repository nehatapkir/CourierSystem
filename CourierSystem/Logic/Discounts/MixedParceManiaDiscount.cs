using System.Collections.Generic;
using System.Linq;

namespace CalculateDeliveryCost
{
    class MixedParceManiaDiscount : ICalculateDiscounts
    {
        public double GetOffer(List<PricePerBox> boxes)
        {
            var list = PackageDetailsUtil.SplitList(boxes);
            double totalPrice = 0;
            foreach (var item in list)
            {
                if(item.Count == 5)
                totalPrice = totalPrice + item[1].Price + item[2].Price + item[3].Price + item[0].Price;
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
