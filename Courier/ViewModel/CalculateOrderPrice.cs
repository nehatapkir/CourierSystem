using CalculateDeliveryCost;

namespace Courier.ViewModel
{
    class CalculateOrderPrice : ICalculateOrderPrice
    {
        private Order order;
        ICalculateDeliveryCost calculateDeliveryCost;

        public CalculateOrderPrice(Order order)
        {
            this.order = order;
            calculateDeliveryCost = new CalculateDeliveryCost.CalculateDeliveryCost();
        }

        public void AddBoxToCurrentOrder(Box box)
        {
            order.Box.Add(box);
        }

        public CalculateDeliveryCost.Receipt CalculateTotalOrderPrice()
        {
           return calculateDeliveryCost.GetTotalCost(order);
        }
    }
}
