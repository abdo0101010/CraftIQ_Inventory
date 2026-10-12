using CraftIQ.Inventory.Core.Entites.Orders;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Orders;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Orders.Read
{
    public class Order(InventoryFactory<dynamic,OrderContract> inventoryFactory):EndpointsAsync.WithoutRequest.WithActionResult<List<OrderResponse>>
    {
        private readonly InventoryFactory<dynamic, OrderContract> _inventoryFactory = inventoryFactory;
        [HttpGet(Routes.Routes.OrderRoutes.BaseUrl)]
        public override async Task<ActionResult<List<OrderResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var Service = _inventoryFactory.Build(nameof(Order));
            var oData = await Service.GetAll();
            var oResult = new List<OrderResponse>();
            foreach(var o in oData)
            {
                var response = new OrderResponse(o.OrderId, o.SupplierId, o.OrderDate, o.TotalAmount, o.Status, o.ExpectedDeliveryDate, o.OrderType, o.ReceivedDate);
                oResult.Add(response);
            }
            return Ok(oResult);

        }
    }
}
