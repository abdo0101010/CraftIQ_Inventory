using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.inventories.Read.ById
{
    public class Inventory(InventoryFactory<dynamic, InventoryContract> factory) : EndpointsAsync.WithRequest<InventoryRequest>.WithActionResult<InventoryResponse>
    {
        private readonly InventoryFactory<dynamic, InventoryContract> _factory = factory;

        [HttpGet(Routes.Routes.InventoryRoutes.ReadInventoryById)]
       
        public override async Task<ActionResult<InventoryResponse>> HandleAsync([FromRoute]InventoryRequest request, CancellationToken cancellationToken = default)
        {
            if (request.InventoryId == Guid.Empty)
            {
                throw new ResultException("InventoryId cannot be empty.", ((int)HttpStatusCode.BadRequest));
            }
            var service=_factory.Build(nameof(CraftIQ.Inventory.Core.Entites.Inventories.Inventory));
            var inventoryContract =await service.GetById(request.InventoryId);
            var oResult = new InventoryResponse(inventoryContract.InventoryId, inventoryContract.Name, inventoryContract.Quantity, inventoryContract.Location);
            return Ok(oResult);

        }
    }
}
