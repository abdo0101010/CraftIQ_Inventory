using Azure;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.inventories.Read
{
    public class Inventory(InventoryFactory<dynamic, InventoryContract> factory) :EndpointsAsync.WithoutRequest.WithActionResult<List<InventoryResponse>>
    {
        private readonly InventoryFactory<dynamic, InventoryContract> _factory = factory;
        
        [HttpGet(Routes.Routes.InventoryRoutes.BaseUrl)]
        public override async Task<ActionResult<List<InventoryResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _factory.Build(nameof(CraftIQ.Inventory.Core.Entites.Inventories.Inventory));
            var inventoryContract = await service.GetAll();
                List<InventoryResponse> responseList = new List<InventoryResponse>();
            foreach (var inventory in inventoryContract)
            {
                var response = new InventoryResponse(inventory.InventoryId, inventory.Name, inventory.Quantity, inventory.Location);

                responseList.Add(response);


            }

            return Ok(responseList);
        }
    }
}
