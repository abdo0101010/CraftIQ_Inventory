using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Orders.spcefication
{
    public class ReadByIdSpcefication: SingleResultSpecification<Order>
    {
        public ReadByIdSpcefication(Guid Id)
        {
            Query.Where(c => c.OrderId == Id);
        }
    }
}
