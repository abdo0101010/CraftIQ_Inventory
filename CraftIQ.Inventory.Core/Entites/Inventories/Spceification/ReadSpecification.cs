using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Inventories.Spceification
{
    public class ReadSpecification: Specification<Inventory>
    {
        public ReadSpecification()
        {
            Query.Where(o => o.InventoryId != Guid.Empty);
        }
    }
}
