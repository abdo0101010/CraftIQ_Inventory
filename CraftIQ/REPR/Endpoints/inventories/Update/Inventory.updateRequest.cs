using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.inventories.Update
{
    public class InventoryRequest
    {
        [FromRoute(Name = "InventoryId")]
        public Guid InventoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;

        public InventoryRequest(Guid inventoryId, string name, int quantity, string location)
        {
            InventoryId = inventoryId;
            Name = name;
            Quantity = quantity;
            Location = location;
        }
        public InventoryRequest() { }
    }
}
