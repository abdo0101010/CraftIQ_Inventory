using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.OrderDetails.spcefication
{
    public class ReadSpcefication: Specification<OrderDetail>
    {
        public ReadSpcefication()
        {
            Query.Where(o => o.OrderDetailsId != Guid.Empty);
        }
    }
}
