using CraftIQ.Inventory.Core.Entites.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites
{
    public class Inventory: BaseEntity
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset LastUpdated { get; set; }
        public Guid ProductId { get; set; }
        public List<Product> Proudects { get; set; } = new List<Product>();
    }
}
