using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using CraftIQ.REPR.Endpoints.Routes;
using CraftIQ.REPR.Endpoints.Transactions.create;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Transactions.update
{
    public class Transactions(InventoryFactory<TransactionOperationContract, TransactionContract> TransactionFactory) : EndpointsAsync.WithRequest<TransactionsRequest>.WithActionResult
    {
        [HttpPut(Routes.Routes.TransactionRoutes.UpdateTransaction)]
        public override async Task<ActionResult> HandleAsync([FromBody]TransactionsRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ResultException("Request cannot be null", 400);
            }
           var service = TransactionFactory.Build(nameof(Transaction));
            var transactionContract = new TransactionOperationContract(
                request.TransactionId,
                request.TransactionDate,
                request.Quantity,
                request.TransactionType,
                request.Notes,
                Guid.Empty
            );
           await service.Update(transactionContract, request.TransactionId);
            return Ok();
        }
    }
}
