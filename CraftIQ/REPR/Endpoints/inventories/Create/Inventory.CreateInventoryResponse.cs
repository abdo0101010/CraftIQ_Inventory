using CraftIQ.Inventory.Shared.Contracts.Inventories;

namespace CraftIQ.REPR.Endpoints.inventories.Create
{
    public class CreateInventoryResponse
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;

        public CreateInventoryResponse( InventoryContract inventoryContract)
        {
            Name = inventoryContract.Name;
            Quantity = inventoryContract.Quantity;
            Location = inventoryContract.Location;
        }
    }
}
