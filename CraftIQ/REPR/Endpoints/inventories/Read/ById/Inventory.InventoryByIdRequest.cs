using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.inventories.Read.ById
{
    public class InventoryRequest
    {
        [FromRoute(Name = "InventoryId")]
        public Guid InventoryId { get; set; }
    }
}
