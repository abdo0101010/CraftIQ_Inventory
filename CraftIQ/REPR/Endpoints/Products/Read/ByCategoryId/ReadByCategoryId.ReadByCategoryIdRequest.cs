using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Products.Read.ByCategoryId
{
    public class ReadByCategoryIdRequest
    {
        [FromRoute]
        public Guid CategoryId { get; set; }
    }
}
