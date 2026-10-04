namespace CraftIQ.REPR.Endpoints.inventories.Create
{
    public class CreateInventoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
