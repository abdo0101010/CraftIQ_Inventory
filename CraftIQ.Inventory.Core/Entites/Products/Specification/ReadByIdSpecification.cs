using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Products.Specification
{
    public class ReadByIdSpecification : Specification<Product>
    {
        public ReadByIdSpecification(Guid ProductId)
        {
            Query.Where(P=>p.ProductId == ProductId);
        }
    }
}
