﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateDeliveryCost
{
    public enum PackageType
    {
        Small,
        Medium,
        Large,
        XL,
        HeavyWeight,
        NA,
    }

    public static class PackageDetailsUtil
    {
        public static IEnumerable<List<PricePerBox>> SplitList(List<PricePerBox> priceBoxMap, int nSize = 3)
        {
            priceBoxMap = priceBoxMap.OrderByDescending(t => t.Price).ToList();
            for (int i = 0; i < priceBoxMap.Count; i += nSize)
            {
                yield return priceBoxMap.GetRange(i, Math.Min(nSize, priceBoxMap.Count - i));
            }
        }

        public static PackageType GetPackageType(Box box)
        {
            if (box.Weight > 50)
            {
                return PackageType.HeavyWeight;
            }

            var dimensions = new List<double>() { box.Length, box.Breadth, box.Height };
           
            if(dimensions.Any(l=> l >= 100))
            {
                return PackageType.XL;
            }
            else if(dimensions.Any(l => l >= 50))
            {
                return PackageType.Large;
            }
            else if (dimensions.Any(l => l >= 10))
            {
                return PackageType.Medium;
            }
            else if (dimensions.All(l => l > 0 && l < 10 ))
            {
                return PackageType.Small;
            }
            return PackageType.NA;
        }
    }
}
