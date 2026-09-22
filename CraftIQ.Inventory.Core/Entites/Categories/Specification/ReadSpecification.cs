using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Categories.Specification
{
    public class ReadSpecification:Specification<Category>
    {
        public ReadSpecification() {
            Query.Where(o => o.Id != 0);
        }
    }
}
