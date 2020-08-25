using CalculateDeliveryCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDeliveryCost
{
    public class CalculateDeliveryCost : ICalculateDeliveryCost
    {   

        public double CalculateDeliveryCostForParcel(PackageType packageType)
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
                default:
                    return 0;
            }
        }

        public double GetCostSpeedDelivery(double initialCost)
        {
            return initialCost * 2;
        }

        public double GetTotalCost(DeliveryOption option)
        {
            var packageType = PackageDetailsUtil.GetPackageType(option.Box);
            var totalCost = CalculateDeliveryCostForParcel(packageType);
            if (option.IsSpeedDelivery)
            {
                totalCost = GetCostSpeedDelivery(totalCost);
            }
            return totalCost;
        } 
    }
}
