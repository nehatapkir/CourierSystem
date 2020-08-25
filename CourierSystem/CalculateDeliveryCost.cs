
namespace CalculateDeliveryCost
{
    public class CalculateDeliveryCost : ICalculateDeliveryCost
    {
        CalculateOverageByWeight calculateOverageByWeight;

        public CalculateDeliveryCost()
        {
            calculateOverageByWeight = new CalculateOverageByWeight();
        }

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
            totalCost += calculateOverageByWeight.GetAdditionalCost(packageType, option.Box);
            if (option.IsSpeedDelivery)
            {
                totalCost = GetCostSpeedDelivery(totalCost);
            }
            return totalCost;
        } 
    }
}
