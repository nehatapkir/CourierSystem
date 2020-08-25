using System.Collections.Generic;
using System.Linq;

namespace CalculateDeliveryCost
{
    class CalculateDiscounts
    {
        internal double ApplyDiscountIfApplicable(List<PricePerBox> pricePerBoxes)
        {
            ICalculateDiscounts calculateDiscounts;

            if (pricePerBoxes.All(b => b.PackageType == PackageType.Small))
            {
                calculateDiscounts = new SmallParcelManiaDiscount();
            }
            else if (pricePerBoxes.All(b => b.PackageType == PackageType.Medium))
            {
                calculateDiscounts = new MediumParcelManiaDiscount();
            }
            else
            {
                calculateDiscounts = new MixedParceManiaDiscount();
            }
            return calculateDiscounts.GetOffer(pricePerBoxes);
        }
    }
}
