using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Orders.Update
{
    public class Order(InventoryFactory<OrderOpertionContract,dynamic>inventoryFactory):EndpointsAsync.WithRequest<OrderRequest>.WithActionResult
    {
        private readonly InventoryFactory<OrderOpertionContract, dynamic> _inventoryFactory=inventoryFactory;
        [HttpPut(Routes.Routes
            .OrderRoutes.UpdateOrder)]
        public override async Task<ActionResult> HandleAsync(OrderRequest request, CancellationToken cancellationToken = default)
        {
            if (request.OrderId == Guid.Empty)
                throw new ResultException("you must send id", ((int)HttpStatusCode.BadRequest));
            var service = _inventoryFactory.Build(nameof(Order));
            var oResult = new OrderOpertionContract(request.OrderId, request.SupplierId, request.OrderDate, request.TotalAmount, request.Status, request.ExpectedDeliveryDate, request.OrderType, request.ReceivedDate);
            await service.Update(oResult, request.OrderId);
            return Ok();
        }
    }
}
