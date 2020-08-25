
namespace CalculateDeliveryCost
{
    public interface ICalculateDeliveryCost
    {
        Receipt GetTotalCost(Order order);
    }
}
