using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Products.Read.ById
{
    public class ReadProductByIdRequest
    {
        [FromRoute]
        public Guid ProductID { get; set; }

    }
}
