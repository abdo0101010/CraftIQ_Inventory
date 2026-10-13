using CraftIQ.Inventory.Core.Entites.OrderDetails;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.OrderDetails.Update
{
    public class OrderDetail(InventoryFactory<OrderDetailOpertionContract, dynamic> inventoryFactory) : EndpointsAsync.WithRequest<OrderDetailRequest>.WithActionResult
    {
        private readonly InventoryFactory<OrderDetailOpertionContract, dynamic> _inventoryFactory = inventoryFactory;
        [HttpPut(Routes.Routes.OrderDetailsRoutes.UpdateOrder)]
        public override async Task<ActionResult> HandleAsync(OrderDetailRequest request, CancellationToken cancellationToken = default)
        {
            if (request.OrderDetailsId == Guid.Empty||request==null)
                throw new ResultException("must send vaild id", ((int)HttpStatusCode.BadRequest));
            var service = _inventoryFactory.Build(nameof(OrderDetail));
            var oData = new OrderDetailOpertionContract(request.Quantity, request.ProductId, request.OrderId, request.TotalPrice);
            await service.Update(oData, request.OrderDetailsId);
            return Ok();

        }
    }
}
