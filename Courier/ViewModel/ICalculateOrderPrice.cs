using CalculateDeliveryCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.ViewModel
{
    interface ICalculateOrderPrice
    {
        void AddBoxToCurrentOrder(Box box);
        CalculateDeliveryCost.Receipt CalculateTotalOrderPrice();
    }
}
