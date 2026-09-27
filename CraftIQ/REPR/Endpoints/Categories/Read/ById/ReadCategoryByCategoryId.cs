using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Categories.Read.ById
{
    public class ReadCategoryByCategoryId(IGenericServices<CategoriesOperationContract, CategoriesContract> services) : EndpointsAsync.WithRequest<ReadCategoryByCategoryIdRequest>.WithActionResult<ReadCategoryByCategoryIdResponse>
    {
        private readonly IGenericServices<CategoriesOperationContract, CategoriesContract> _services = services;
        [HttpGet(Routes.Routes.CategoriesRoutes.ReadCategoryByCategoryId)]
        public override async Task<ActionResult<ReadCategoryByCategoryIdResponse>> HandleAsync([FromRoute]ReadCategoryByCategoryIdRequest request, CancellationToken cancellationToken = default)
        {
            var OData =await _services.GetById(request.CategoryId);
            var OResult = new ReadCategoryByCategoryIdResponse(OData.CategoryId, OData.Name, OData.Description, OData.CreatedOn, OData.CreatedBY, OData.ModifiedOn, OData.ModifiedBy);
            return Ok(OResult);
        }
    }
}
