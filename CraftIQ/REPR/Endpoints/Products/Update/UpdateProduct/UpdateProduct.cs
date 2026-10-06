using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Services.ProductsImplemention;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Products.Update.UpdateProduct
{
    public class UpdateProduct(InventoryFactory<ProductOperationContract,dynamic> Factory) : EndpointsAsync.WithRequest<UpdateProductRequest>.WithActionResult
    {
        private readonly InventoryFactory<ProductOperationContract, dynamic> _Factory = Factory;
        [HttpPut(Routes.Routes.ProductRoutes.UpdateProduct)]
        public override async Task<ActionResult> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ResultException("you cannot send empty product", ((int)HttpStatusCode.BadGateway));
            var Service = _Factory.Build(nameof(Product));
            var UpdatedProduct = new ProductOperationContract(
                                                       request.ProductId,
                                                       request.InventoryId,
                                                       request.Name,
                                                       request.Description,
                                                       request.UnitPrice,
                                                       request.Weight,
                                                       request.Length,
                                                       request.Width,
                                                       request.Height,
                                                       Guid.Empty,
                                                       request.TaxCost,
                                                       request.ProfitPerUnit,
                                                       request.ProductionCost);

           await Service.Update(UpdatedProduct,request.ProductId);
            return Ok("your object has been updated");
        }
    }
}
