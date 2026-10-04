using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.inventories.Delete
{
    public class CategoryRequest
    {
        [FromRoute(Name = "InventoryId")]
        public Guid InventoryId { get; set; }
    }
}
