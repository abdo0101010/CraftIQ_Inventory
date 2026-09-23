using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Products.Specification
{
    public class ReadSpecification: Specification<Product>
    {
        public ReadSpecification()
        {
            Query.Where(p => p.Id != 0);
        }

    }
}
