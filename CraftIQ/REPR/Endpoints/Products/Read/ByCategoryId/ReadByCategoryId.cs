using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Products.Read.ByCategoryId
{
    public class ReadByCategoryId(InventoryFactory<dynamic,ProductContract> factory) : EndpointsAsync.WithRequest<ReadByCategoryIdRequest>.WithActionResult<List<ReadByCategoryIdResponse>>
    {
        
        private readonly InventoryFactory<dynamic, ProductContract> _factory = factory;
        [HttpGet(Routes.Routes.ProductRoutes.ReadProductByCategoryId)]
        public override async Task<ActionResult<List<ReadByCategoryIdResponse>>> HandleAsync(ReadByCategoryIdRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("you must send id for request", ((int)HttpStatusCode.BadRequest));
            var service = _factory.Build(nameof(Product));
            var OData =await service.GetByParentId(request.CategoryId);
            var OResult = OData.Adapt <List<ReadByCategoryIdResponse>>();
            return Ok(OResult);

        }
    }
}
