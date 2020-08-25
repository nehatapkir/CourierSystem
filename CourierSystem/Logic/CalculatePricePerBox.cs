using System.Collections.Generic;

namespace CalculateDeliveryCost
{
    class CalculatePricePerBox
    {
        CalculateOverageByWeight calculateOverageByWeight;

        public CalculatePricePerBox()
        {
            calculateOverageByWeight = new CalculateOverageByWeight();
        }

        private double CalculateDeliveryCostForParcel(PackageType packageType)
        {
            switch (packageType)
            {
                case (PackageType.Small):
                    return 3;
                case (PackageType.Medium):
                    return 8;
                case (PackageType.Large):
                    return 15;
                case (PackageType.XL):
                    return 25;
                case (PackageType.HeavyWeight):
                    return 50;
                default:
                    return 0;
            }
        }

        internal List<PricePerBox> GetPricePerBox(Order order)
        {
            var pricePerBox = new List<PricePerBox>();
            foreach (var box in order.Box)
            {
                var packageType = PackageDetailsUtil.GetPackageType(box);
                var totalCostPerBOx = CalculateDeliveryCostForParcel(packageType);
                totalCostPerBOx += calculateOverageByWeight.GetAdditionalCost(packageType, box);
                pricePerBox.Add(new PricePerBox
                {
                    PackageType = packageType,
                    Price = totalCostPerBOx,
                    Length = box.Length,
                    Height = box.Height,
                    Breadth = box.Breadth,
                    Weight = box.Weight
                });
            }
            return pricePerBox;
        }
    }
}
