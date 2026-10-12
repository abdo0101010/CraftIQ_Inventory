using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Orders.Read.ById
{
    public class Order(InventoryFactory<OrderOpertionContract,OrderContract> inventoryFactory) : EndpointsAsync.WithRequest<OrderRequest>.WithActionResult<OrderResponse>
    {
        private readonly InventoryFactory<OrderOpertionContract, OrderContract> _inventoryFactory = inventoryFactory;
        [HttpGet(Routes.Routes.OrderRoutes.ReadOrderById)]
        public override async Task<ActionResult<OrderResponse>> HandleAsync(OrderRequest request, CancellationToken cancellationToken = default)
        {
            if (request.OrderId == Guid.Empty)
                throw new ResultException("must send really id", ((int)HttpStatusCode.BadRequest));
            var Service = _inventoryFactory.Build(nameof(Order));
            var oData = await Service.GetById(request.OrderId);
            var oResult = new OrderResponse(oData.OrderId, oData.SupplierId, oData.OrderDate, oData.TotalAmount, oData.Status, oData.ExpectedDeliveryDate, oData.OrderType, oData.ReceivedDate);
            return Ok(oResult);
               
        }
    }
}
