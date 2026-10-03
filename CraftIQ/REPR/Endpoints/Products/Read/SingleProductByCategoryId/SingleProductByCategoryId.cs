using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Products.Read.SingleProductByCategoryId
{
    public class SingleProductByCategoryIdDeleteProduct(InventoryFactory<ProductContract, ProductOperationContract> factory) : EndpointsAsync.WithRequest<SingleProductByCategoryIdRequest>.WithActionResult<SingleProductByCategoryIdResponse>
    {

        private readonly InventoryFactory<ProductContract, ProductOperationContract> _factory = factory;
        [HttpGet("get-single-by-category-id")]
        public override async Task<ActionResult<SingleProductByCategoryIdResponse>> HandleAsync(
    [FromQuery] SingleProductByCategoryIdRequest request,
    CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("cant send null id", (int)HttpStatusCode.BadRequest);

            var service = _factory.Build(nameof(Product));
            var OData = await service.GetSingleByParentId(request.CategoryId, request.ProductId);

            var OResult = new SingleProductByCategoryIdResponse(
                OData.ProductId, OData.Name, OData.Description, OData.UnitPrice,
                OData.Weight, OData.Length, OData.Width, OData.Height,
                OData.CategoryId, OData.TaxCost, OData.ProfitPerUnit, OData.ProductionCost
            );

            return OResult;
        }
    }
}
