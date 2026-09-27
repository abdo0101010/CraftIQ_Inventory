using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Categories.Create
{
    public class CreateCategories(InventoryFactory<CategoriesOperationContract, CategoriesOperationContract> factory)
            : EndpointsAsync.WithRequest<CreateCategoriesRequest>.WithActionResult<CreateCategoriesRepsonse>
    {
        InventoryFactory<CategoriesOperationContract, CategoriesOperationContract>  _factory = factory;
               [HttpPost(Routes.Routes.CategoriesRoutes.Create)]
        public override async Task<ActionResult<CreateCategoriesRepsonse>> HandleAsync(CreateCategoriesRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ResultException("Request cannot be null", StatusCodes.Status400BadRequest);
            }
            var contractInput = new CategoriesOperationContract(request.Name, request.Description);
            var service = _factory.Build(nameof(Category));

            var oData = new CategoriesOperationContract(request.Name, request.Description);
            var oResult = await service.Create(oData);
            return Ok(new CreateCategoriesRepsonse(oResult.Name, oResult.Description));
        }
    }
}
