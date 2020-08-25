using System.Collections.Generic;

namespace CalculateDeliveryCost
{
    interface ICalculateDiscounts
    {
        double GetOffer(List<PricePerBox> boxes);
    }
}
