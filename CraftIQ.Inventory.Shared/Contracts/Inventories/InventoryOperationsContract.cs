using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Shared.Contracts.Inventories
{
    public class InventoryOperationsContract
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }
    }
}
