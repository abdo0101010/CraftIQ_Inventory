namespace CraftIQ.Inventory.Shared.Contracts.Inventories
{
    public class InventoryContract
    {
        public Guid InventoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
        public InventoryContract(Guid Inventoryid,string name,int quantity,string location)
        {
            InventoryId = Inventoryid;
            Name = name;
            Quantity = quantity;
            Location = location;
        }

    }
}
