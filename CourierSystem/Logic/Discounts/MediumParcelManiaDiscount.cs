﻿using System.Collections.Generic;
using System.Linq;

namespace CalculateDeliveryCost
{
    class MediumParcelManiaDiscount : ICalculateDiscounts
    {
        public double GetOffer(List<PricePerBox> boxes)
        {
            var list = PackageDetailsUtil.SplitList(boxes);
            double totalPrice = 0;
            foreach (var item in list)
            {
                if(item.Count == 3)
                totalPrice = totalPrice + item[1].Price + item[0].Price;
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
