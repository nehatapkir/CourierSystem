using CalculateDeliveryCost;

namespace CalculateDeliveryCost
{
    public class PricePerBox
    {
        public PackageType PackageType { get; set; }
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
    }
}
