namespace CalculateDeliveryCost
{
    class CalculateOverageByWeight 
    {
        public double GetAdditionalCost(PackageType packageType, Box box)
        {
            var weight = box.Weight;
            switch (packageType)
            {
                case (PackageType.Small):
                    return CalculateExcessCost(1,  weight);
                case (PackageType.Medium):
                    return CalculateExcessCost(3, weight);
                case (PackageType.Large):
                    return CalculateExcessCost(6, weight);
                case (PackageType.XL):
                    return CalculateExcessCost(10, weight);        
                default:
                    return 0;
            }
        }

        private double CalculateExcessCost(double referenceWeight, double weight, double costPerKg = 2)
        {
            var excess = weight - referenceWeight;
            return excess > 0 ? excess * costPerKg : 0;
        }
    }
}
 
