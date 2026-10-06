using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using CraftIQ.REPR.Endpoints.Routes;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Products.Create
{
    public class CreateProduct(InventoryFactory<ProductOperationContract, ProductContract> ProductFactory) : EndpointsAsync.WithRequest<CreateProductRequest>.WithActionResult<CreateProductResponse>
    {
        InventoryFactory<ProductOperationContract, ProductContract> _ProductFactory = ProductFactory;
        [HttpPost(Routes.Routes.ProductRoutes.Create)]
        public override async Task<ActionResult<CreateProductResponse>> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("cannot send null request", ((int)HttpStatusCode.BadRequest));
            var services = _ProductFactory.Build(nameof(Product));
            var operationContract = new ProductOperationContract(Guid.Empty, request.InventoryId, request.Name, request.Description, request.UnitPrice, request.Weight, request.Length, request.Width, request.Height, request.CategoryId, request.TaxCost, request.ProfitPerUnit, request.ProductionCost);
           var oData= await services.Create(operationContract);
            var OResult = new CreateProductResponse(oData.ProductId);
            return Ok(OResult);

        }
    }
}
