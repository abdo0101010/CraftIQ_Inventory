using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Orders.Create
{
    public class Order(InventoryFactory<OrderOpertionContract,OrderContract> inventoryFactory) :EndpointsAsync.WithRequest<OrderRquest>.WithActionResult<OrderResponse>
    {
        private readonly InventoryFactory<OrderOpertionContract, OrderContract> _inventoryFactory = inventoryFactory;
        [HttpPost(Routes.Routes.OrderRoutes.Create)]
        public override async Task<ActionResult<OrderResponse>> HandleAsync(OrderRquest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("cannot be send null Request", ((int)HttpStatusCode.BadRequest));
            var Service = _inventoryFactory.Build(nameof(Order));
            var oData = new OrderOpertionContract(Guid.Empty, Guid.Empty, request.OrderDate, request.TotalAmount, request.Status, request.ExpectedDeliveryDate, request.OrderType, request.ReceivedDate);
          var Response=  await Service.Create(oData);
            var OResult = new OrderContract(Response.OrderId, Response.SupplierId, Response.OrderDate, Response.TotalAmount, Response.Status, Response.ExpectedDeliveryDate, Response.OrderType, Response.ReceivedDate);
            return Ok(OResult);


        }
    }
}
