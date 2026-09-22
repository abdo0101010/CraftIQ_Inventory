using CraftIQ.Inventory.Core.interfaces;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Categories.Read
{
    public class ReadCategories(ICateegoriesServices services) : EndpointsAsync.WithoutRequest.WithActionResult<ReadCategoriesResponse>
    {
        private readonly ICateegoriesServices _services = services;
        [HttpGet(Routes.Routes.CategoriesRoutes.baseUrl)]
        public override async Task<ActionResult<ReadCategoriesResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var OData = await _services.GetAllCategories();
            //var OResult = OData.Select(o => new ReadCategoriesResponse(o.CategoryId, o.Name, o.CreatedOn, o.CreatedBY, o.ModifiedOn, o.ModifiedBy);
            return Ok(OData);

        }
    }
}
