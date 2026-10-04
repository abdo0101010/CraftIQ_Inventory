using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.inventories.Create
{
    public class CreateInventory(InventoryFactory<InventoryOperationsContract, InventoryContract> factory): EndpointsAsync.WithRequest<CreateInventoryRequest>.WithActionResult<CreateInventoryResponse>  
    {
        private readonly InventoryFactory<InventoryOperationsContract, InventoryContract> _factory = factory;
        [HttpPost(Routes.Routes.InventoryRoutes.Create)]
        public override async Task<ActionResult<CreateInventoryResponse>> HandleAsync(CreateInventoryRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ResultException("Request cannot be null", (int)HttpStatusCode.BadRequest);
            }

            var service = _factory.Build(nameof(Inventory.Core.Entites.Inventories.Inventory));

            if (service == null)
            {
                throw new ResultException("Failed to resolve Inventory Service from factory", (int)HttpStatusCode.InternalServerError);
            }

            var inventoryContract = new InventoryOperationsContract
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Location = request.Location
            };

            var result = await service.Create(inventoryContract);

            var response = new InventoryContract(result.InventoryId, result.Name, result.Quantity, result.Location);

            var createInventoryResponse = new CreateInventoryResponse(response);
          
            return Ok(createInventoryResponse);

        }
    }
}
