using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using CraftIQ.REPR.Endpoints.Transactions.delete;
using huzcodes.Endpoints.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CraftIQ.REPR.Endpoints.Transactions.read
{
    public class Transactions(InventoryFactory<TransactionOperationContract, TransactionContract> TransactionFactory) : EndpointsAsync.WithoutRequest.WithActionResult<List<TransactionsReaponse>>
    {
        private readonly InventoryFactory<TransactionOperationContract, TransactionContract> _TransactionFactory = TransactionFactory;
        [HttpGet(Routes.Routes.TransactionRoutes.BaseUrl)]
        public override async Task<ActionResult<List<TransactionsReaponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var service = _TransactionFactory.Build(nameof(Transaction));
            var oData = await service.GetAll();
            var OResult = oData.Select(x => new TransactionsReaponse(x.TransactionId, x.TransactionDate, x.Quantity, x.TransactionType, x.Notes, x.EmployeeId, x.CreatedOn, x.CreatedBY, x.ModifiedOn, x.ModifiedBy)).ToList();

            return Ok(OResult);
        }
    }
}
