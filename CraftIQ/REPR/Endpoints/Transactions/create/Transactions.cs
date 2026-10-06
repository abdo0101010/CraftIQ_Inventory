using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Services.TransactionImplemention;
using CraftIQ.Inventory.Shared.Contracts.Products;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Transactions.create
{
    public class Transactions(InventoryFactory<TransactionOperationContract, TransactionContract> TransactionFactory) : EndpointsAsync.WithRequest<TransactionRequest>.WithActionResult
    {

        private readonly InventoryFactory<TransactionOperationContract, TransactionContract > _TransactionFactory=TransactionFactory;
        [HttpPost(Routes.Routes.TransactionRoutes.Create)]
        public override async Task<ActionResult> HandleAsync(TransactionRequest request, CancellationToken cancellationToken = default)
        {
          if (request == null)
            {
               throw new ResultException("Request cannot be null", 400);
            }
          var service = _TransactionFactory.Build(nameof(Transaction));
            var transactionContract = new TransactionOperationContract(Guid.Empty,request.TransactionDate, request.Quantity, request.TransactionType, request.Notes,Guid.Empty);
            await service.Create(transactionContract);
            return Ok();



        }
    }
}
