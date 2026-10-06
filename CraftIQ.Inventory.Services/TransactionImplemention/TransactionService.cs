using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Transactions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CraftIQ.Inventory.Services.TransactionImplemention
{
    public class TransactionService<TRequest, TResponse>(IRepository<Transaction> repository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Transaction> _repository = repository;
        public async ValueTask<TResponse> Create(TRequest contract)
        {
            var oContract=contract as TransactionOperationContract;
            var entity = new Transaction(Guid.Empty, oContract.TransactionDate, oContract.Quantity, oContract.TransactionType, oContract.Notes, oContract.EmployeeId);
            var oResult= await _repository.AddAsync(entity);
            var result = new TransactionContract(oResult.TransactionId, oResult.TransactionDate, oResult.Quantity, oResult.TransactionType, oResult.Notes, oResult.EmployeeId, oResult.CreatedBY, oResult.ModifiedBy, oResult.CreatedOn, oResult.ModifiedOn);
            return result as dynamic;

        }

        public async ValueTask Delete(Guid ContractId)
        {
          var spec = new Core.Entites.Transactions.Specification.ReadByIdSpecification(ContractId);
            var oData = await _repository.FirstOrDefaultAsync(spec);
            if (oData == null)
                throw new ResultException("Data not found",((int)HttpStatusCode.NotFound));

            await _repository.DeleteAsync(oData);



        }

        public async ValueTask<List<TResponse>> GetAll()
        {
            var spec = new Core.Entites.Transactions.Specification.ReadSpecification();
            var oData = await _repository.ListAsync(spec);
            var oResult = oData.Select(x => new TransactionContract(x.TransactionId,x.TransactionDate, x.Quantity, x.TransactionType, x.Notes, x.EmployeeId, x.CreatedBY, x.ModifiedBy, x.CreatedOn, x.ModifiedOn)).ToList() as List<TResponse>;
            return oResult as dynamic ;
        }

        public async ValueTask<TResponse> GetById(Guid ContractId)
        {
          var spec = new Core.Entites.Transactions.Specification.ReadByIdSpecification(ContractId);
            var oData = await _repository.FirstOrDefaultAsync(spec);
            if (oData == null)
                throw new ResultException("Data not found", ((int)HttpStatusCode.NotFound));
            var oResult = new TransactionContract(oData.TransactionId,oData.TransactionDate, oData.Quantity, oData.TransactionType, oData.Notes, oData.EmployeeId, oData.CreatedBY, oData.ModifiedBy, oData.CreatedOn, oData.ModifiedOn) as dynamic;
            return oResult;
        }

        public async ValueTask<List<TResponse>> GetByParentId(Guid parentId)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<TResponse> GetSingleByParentId(Guid parentId, Guid id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask Update(TRequest contract, Guid id)
        {
            var spec = new Core.Entites.Transactions.Specification.ReadByIdSpecification(id);
            var oData = await _repository.FirstOrDefaultAsync(spec);
            if (oData == null)
                throw new ResultException("Data not found", ((int)HttpStatusCode.NotFound));
            var oContract = contract as TransactionOperationContract;
            oData.UpdateTransaction(oContract.TransactionDate, oContract.Quantity, oContract.TransactionType, oContract.Notes, oContract.EmployeeId, Guid.Empty);
            await _repository.UpdateAsync(oData);
        }

        public async ValueTask UpdateParentId(Guid ContractId, Guid parentId)
        {
            throw new NotImplementedException();
        }
    }
}
