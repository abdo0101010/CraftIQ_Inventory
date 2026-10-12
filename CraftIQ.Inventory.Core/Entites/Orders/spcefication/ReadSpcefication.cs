using Ardalis.Specification;
namespace CraftIQ.Inventory.Core.Entites.Orders.spcefication
{
    public class ReadSpcefication : Specification<Order>
    {
        public ReadSpcefication()
        {
            Query.Where(o => o.OrderId != Guid.Empty);
        }
    }
}
