using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.OrderDetails.spcefication
{
    public class ReadByIdSpcefication:SingleResultSpecification<OrderDetail>
    {
        public ReadByIdSpcefication(Guid Id)
        {
            Query.Where(c => c.OrderDetailsId == Id);

        }
    }

}
