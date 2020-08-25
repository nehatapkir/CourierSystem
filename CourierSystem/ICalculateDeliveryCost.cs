using CalculateDeliveryCost;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateDeliveryCost
{
    public interface ICalculateDeliveryCost
    {
        double GetTotalCost(DeliveryOption option);
    }
}
