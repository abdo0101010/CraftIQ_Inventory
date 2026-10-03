using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Products.Delete
{
    public class DeleteProduct(InventoryFactory<ProductOperationContract,dynamic> factory):EndpointsAsync.WithRequest<DeleteProductRequest>.WithoutResult
    {

        private readonly InventoryFactory<ProductOperationContract, dynamic> _factory = factory;
        [HttpDelete(Routes.Routes.ProductRoutes.Delete)]
        public override async Task HandleAsync(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new ResultException("Request cannot be null.", ((int)HttpStatusCode.BadRequest));
            var service = _factory.Build(nameof(Product));
            await service.Delete(request.ProductId);

        }

    
    }
}
