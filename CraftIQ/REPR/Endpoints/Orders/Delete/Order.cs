using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Orders.Delete
{
    public class Order(InventoryFactory<OrderOpertionContract, dynamic> inventoryFactory) : EndpointsAsync.WithRequest<OrderRequest>.WithActionResult
    {
        
        private readonly InventoryFactory<OrderOpertionContract, dynamic> _inventoryFactory = inventoryFactory;
        [HttpDelete(Routes.Routes.OrderRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(OrderRequest request, CancellationToken cancellationToken = default)
        {
            if (request.OrderId == Guid.Empty)
                throw new ResultException("must send really id ",((int)HttpStatusCode.BadRequest));
            var servicee = _inventoryFactory.Build(nameof(Order));
            await servicee.Delete(request.OrderId);
            return Ok();

        }
    }
}
