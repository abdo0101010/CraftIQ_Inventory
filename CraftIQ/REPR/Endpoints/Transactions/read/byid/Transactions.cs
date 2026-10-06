using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using huzcodes.Endpoints.Abstractions;
using huzcodes.Extensions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Transactions.read.byid
{
    public class Transactions(InventoryFactory<TransactionOperationContract, TransactionContract> TransactionFactory) : EndpointsAsync.WithRequest<TransactionsRequest>.WithActionResult<TransactionsResponse>
    {
        private readonly InventoryFactory<TransactionOperationContract, TransactionContract> _TransactionFactory = TransactionFactory;
        [HttpGet(Routes.Routes.TransactionRoutes.ReadTransactionById)]
        public override async Task<ActionResult<TransactionsResponse>> HandleAsync(TransactionsRequest request, CancellationToken cancellationToken = default)
        {
            if (request.TransactionId == Guid.Empty)
            {
               throw new ResultException("TransactionId is required", 400);
            }
            var service = _TransactionFactory.Build(nameof(Transaction));
            var oData = await service.GetById(request.TransactionId);
            var OResult = new TransactionsResponse(oData.TransactionId, oData.TransactionDate, oData.Quantity, oData.TransactionType, oData.Notes, oData.EmployeeId, oData.CreatedOn, oData.CreatedBY, oData.ModifiedOn, oData.ModifiedBy);
            return Ok(OResult);
        }
    }
}
