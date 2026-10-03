using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Services.ProductsImplemention;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Products.Update.UpdateParentId
{
    public class UpdateParentId (InventoryFactory<ProductOperationContract,dynamic> Factory) : EndpointsAsync.WithRequest<UpdateParentIdRequest>.WithActionResult
    {
       private readonly InventoryFactory<ProductOperationContract, dynamic> _Factory = Factory;
        [HttpPut(Routes.Routes.ProductRoutes.UpdateCategoryId)]
        public override async Task<ActionResult> HandleAsync(UpdateParentIdRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                return await Task.FromResult<ActionResult>(BadRequest("Request cannot be null."));
            var service = _Factory.Build(nameof(Product));
             await service.UpdateParentId(request.ProductId, request.ParentId);
            return Ok();
        }
    }
}
