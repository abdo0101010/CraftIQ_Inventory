using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Categories.Create
{
    public class CreateCategories(ICateegoriesServices categoriesServices) : EndpointsAsync.WithRequest<CreateCategoriesRequest>.WithActionResult<CreateCategoriesRepsonse>
    {
        private readonly ICateegoriesServices _categoriesServices = categoriesServices;
        [HttpPost(Routes.Routes.CategoriesRoutes.Create)]
        public override async Task<ActionResult<CreateCategoriesRepsonse>> HandleAsync(CreateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ResultException("Request cannot be null", StatusCodes.Status400BadRequest);
            }
            var OData = new CategoriesOperationContract(request.Name, request.Description);

            var OResult = await _categoriesServices.CreateCategory(OData);


            return Ok(new CreateCategoriesRepsonse(OResult.Name, OResult.Description));
        }
    }
}
