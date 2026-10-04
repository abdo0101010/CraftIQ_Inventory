using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.inventories.Update
{
    public class Inventory(InventoryFactory<InventoryOperationsContract,dynamic> factory) : EndpointsAsync.WithRequest<InventoryRequest>.WithoutResult
    {
        private readonly InventoryFactory<InventoryOperationsContract, dynamic> _factory = factory;
        [HttpPut(Routes.Routes.InventoryRoutes.UpdateInventory)]
        public override async Task<ActionResult> HandleAsync(InventoryRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ResultException("Inventory request cannot be null.", 400);
            }

            var service = _factory.Build(nameof(CraftIQ.Inventory.Core.Entites.Inventories.Inventory));
            var contract = new InventoryOperationsContract(request.Name, request.Quantity, request.Location);
            await service.Update(contract,request.InventoryId);
            return Ok();
        }
    }
}
