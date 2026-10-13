using CraftIQ.Inventory.Core.Entites.OrderDetails;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.OrderDetails;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.OrderDetails.Create
{
    public class OrderDetail(InventoryFactory<OrderDetailOpertionContract,OrderDetailContract> inventoryFactory):EndpointsAsync.WithRequest<OrderDetailRequest>.WithActionResult<OrderDetailResponce>
    {
        private readonly InventoryFactory<OrderDetailOpertionContract, OrderDetailContract> _inventoryFactory = inventoryFactory;
        [HttpPost(Routes.Routes.OrderDetailsRoutes.Create)]
        public override async Task<ActionResult<OrderDetailResponce>> HandleAsync(OrderDetailRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("cannoy send null request", ((int)HttpStatusCode.BadRequest));
            var service = _inventoryFactory.Build(nameof(OrderDetail));
            var oData = new OrderDetailOpertionContract(request.Quantity, request.ProductId, request.OrderId, request.TotalPrice);
            var oResult =await service.Create(oData);
            var Responce = new OrderDetailResponce(oResult.Quantity, oResult.ProductId, oResult.OrderId, oResult.TotalPrice);
            return Ok(Responce);

        }
    }
}
