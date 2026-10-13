using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;

using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.OrderDetails.Read
{
    public class OrderDetail(InventoryFactory<dynamic, OrderDetailContract> inventoryFactory) : EndpointsAsync.WithoutRequest.WithActionResult<List<OrderDetailResponse>>
    {
        private readonly InventoryFactory<dynamic, OrderDetailContract> _inventoryFactory = inventoryFactory;
        [HttpGet(Routes.Routes.OrderDetailsRoutes.BaseUrl)]
        public override async Task<ActionResult<List<OrderDetailResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _inventoryFactory.Build(nameof(OrderDetail));
           var oData = await service.GetAll();
            var oResult = new List<OrderDetailResponse>();
            foreach(var o in oData)
            {
                var orderdetail = new OrderDetailResponse(o.OrderDetailsId,o.Quantity, o.ProductId, o.OrderId, o.TotalPrice);
                oResult.Add(orderdetail);
            }
            return Ok(oResult);
        }
    }
}
