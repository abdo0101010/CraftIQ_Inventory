namespace CraftIQ.REPR.Endpoints.inventories.Read.ById
{
    public class InventoryResponse
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;

        public InventoryResponse(Guid inventoryId, string name, int quantity, string location)
        {
            InventoryId = inventoryId;
            Name = name;
            Quantity = quantity;
            Location = location;
        }
    }
}
