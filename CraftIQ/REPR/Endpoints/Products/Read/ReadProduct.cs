using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace CraftIQ.REPR.Endpoints.Products.Read
{
    public class ReadProduct(InventoryFactory<dynamic, ProductContract> ProductFactory) : EndpointsAsync.WithoutRequest.WithActionResult<List<ReadProductResponse>>
    {
        InventoryFactory<dynamic, ProductContract> _ProductFactory = ProductFactory;
        [HttpGet(Routes.Routes.ProductRoutes.baseUrl)]
        public async override Task<ActionResult<List<ReadProductResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service =  _ProductFactory.Build(nameof(Product));
            var OResult =await service.GetAll();
            // يتحول السطر بدلاً من Select إلى:
            var oData = OResult.Adapt<List<ReadProductResponse>>();
            return Ok(oData);
        }
    }
}
