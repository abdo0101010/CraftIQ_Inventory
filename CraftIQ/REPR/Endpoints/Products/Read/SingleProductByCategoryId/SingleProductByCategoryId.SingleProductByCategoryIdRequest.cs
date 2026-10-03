using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Products.Read.SingleProductByCategoryId
{
    public class SingleProductByCategoryIdRequest
    {
        [FromQuery(Name = "ProductId")]
        public Guid ProductId { get; set; }
        [FromQuery(Name = "CategoryId")]
        public Guid CategoryId { get; set; }
    }
}
