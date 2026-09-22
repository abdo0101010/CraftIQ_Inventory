using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Categories.Update
{
    public class UpdateCategory(ICateegoriesServices services) : EndpointsAsync.WithRequest<UpdateCategoryRequest>.WithActionResult<UpdateCategoryResponse>
    {
        private readonly ICateegoriesServices _services = services;
        [HttpPut(Routes.Routes.CategoriesRoutes.UpdateCategory)]
        public override async Task<ActionResult<UpdateCategoryResponse>> HandleAsync(UpdateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            //var OData = _services.UpdateCategory(request, request.CategoryId);
            var OData = new CategoriesOperationContract(request.Name, request.Description);

            await _services.UpdateCategory(OData, request.CategoryId);

            var response = new UpdateCategoryResponse(request.CategoryId, request.Name, request.Description, request.CreatedOn, request.CreatedBY, request.ModifiedOn, request.ModifiedBy);

            return Ok(response);


        }
    }
}
