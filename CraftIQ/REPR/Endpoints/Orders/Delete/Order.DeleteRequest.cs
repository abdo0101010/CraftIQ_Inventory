using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Orders.Delete
{
    public class OrderRequest
    {
        [FromRoute]
        public Guid OrderId { get; set; }
    }
}
