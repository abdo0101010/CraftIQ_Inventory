using CraftIQ.Inventory.Core.Entites.OrderDetails;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using CraftIQ.REPR.Endpoints.OrderDetails.Create;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.OrderDetails.Delete
{
    public class OrderDetail(InventoryFactory<OrderDetailOpertionContract, OrderDetailContract> inventoryFactory) : EndpointsAsync.WithRequest<OrderDetailRequest>.WithActionResult
    {
        private readonly InventoryFactory<OrderDetailOpertionContract, OrderDetailContract> _inventoryFactory = inventoryFactory;
        [HttpDelete(Routes.Routes.OrderDetailsRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(OrderDetailRequest request, CancellationToken cancellationToken = default)
        {
            if (request.OrderDetailId == Guid.Empty)
                throw new ResultException("must send vaild id", ((int)HttpStatusCode.BadRequest));
            var service = _inventoryFactory.Build(nameof(OrderDetail));
            await service.Delete(request.OrderDetailId);
            return Ok();
        }
    }
}
