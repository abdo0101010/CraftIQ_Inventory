using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Products.Delete
{
    public class DeleteProductRequest
    {
        [FromRoute(Name = "ProductId")]
        public Guid ProductId { get; set; }
    }
}
