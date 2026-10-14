using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Categories.Read.ById
{
    public class ReadCategoryByCategoryIdRequest
    {
        [FromRoute(Name = "CategoryID")]
        public Guid CategoryId { get; set; }
    }
}
