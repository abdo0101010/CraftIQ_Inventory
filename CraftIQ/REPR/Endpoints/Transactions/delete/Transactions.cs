using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CraftIQ.REPR.Endpoints.Transactions.delete
{
    public class Transactions(InventoryFactory<TransactionOperationContract,TransactionContract> TransactionFactory) : EndpointsAsync.WithRequest<TransactionsRequest>.WithActionResult
    {
        private readonly InventoryFactory<TransactionOperationContract, TransactionContract> _TransactionFactory = TransactionFactory;
        [HttpDelete(Routes.Routes.TransactionRoutes.Delete)]
        public override async Task<ActionResult> HandleAsync(TransactionsRequest request, CancellationToken cancellationToken = default)
        {
           if(request.TransactionId == Guid.Empty)
            {
                throw new ResultException("TransactionId is required",((int)HttpStatusCode.BadRequest));
            }
           var service = _TransactionFactory.Build(nameof( Transaction));
            await service.Delete(request.TransactionId);
            return Ok();

        }
    }
}
