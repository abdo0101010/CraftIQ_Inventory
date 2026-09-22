using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.interfaces;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace CraftIQ.REPR.Endpoints.Categories.Delete
{
    public class DeleteCategory(ICateegoriesServices services) : EndpointsAsync.WithRequest<DeleteCategoryRequest>.WithActionResult<DeleteCategoryResponse>
    {
        private readonly ICateegoriesServices _services = services;
        [HttpDelete(Routes.Routes.CategoriesRoutes.Delete)]
        public override async Task<ActionResult<DeleteCategoryResponse>> HandleAsync(
              [FromRoute] DeleteCategoryRequest request,
              CancellationToken cancellationToken = default)
        {
            

            var category = await _services.GetCategoryByCategoryId(request.CategoryId);


            await _services.DeleteCategoryByCategoryId(request.CategoryId);

            return Ok(new DeleteCategoryResponse(true));
        }
    }
}
