using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.inventories.Delete
{
    public class Inventory(InventoryFactory<InventoryOperationsContract,dynamic> factory) : EndpointsAsync.WithRequest<CategoryRequest>.WithActionResult
    {
        private readonly InventoryFactory<InventoryOperationsContract, dynamic> _factory = factory;
        [HttpDelete(Routes.Routes.InventoryRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync([FromRoute]CategoryRequest request, CancellationToken cancellationToken = default)
        {
            if (request.InventoryId == Guid.Empty)
            {
                throw new ResultException("InventoryId cannot be empty.", ((int)HttpStatusCode.BadRequest));
            }
            var service = _factory.Build(nameof(CraftIQ.Inventory.Core.Entites.Inventories.Inventory));
            await service.Delete(request.InventoryId);
            return Ok();


        }
    }
}
