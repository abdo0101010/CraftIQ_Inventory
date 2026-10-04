using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Inventories.Spceification
{
    public class ReadByIdSpceifecation:SingleResultSpecification<Inventory>
    {
        public ReadByIdSpceifecation(Guid ContractId)
        {
            Query.Where(c => c.InventoryId == ContractId);

        }
    }
}
