using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CraftIQ.Inventory.Services.InventoriesImplemention
{
    public class InventoryServices<TRequest, TResponse>(IRepository<Core.Entites.Inventories.Inventory> repository) : IGenericServices<TRequest, TResponse>
    {
        private readonly IRepository<Core.Entites.Inventories.Inventory> _repository = repository;
        public async ValueTask<TResponse> Create(TRequest contract)
        {
            var oContract = contract as InventoryOperationsContract;
            if (oContract == null)
            {
                throw new ArgumentException("Invalid contract type");
            }
            var entity = new Core.Entites.Inventories.Inventory( oContract.Name, oContract.Quantity, oContract.Location, DateTimeOffset.UtcNow);

            var OResult=new InventoryContract(entity.InventoryId, entity.Name, entity.Quantity, entity.Location);

            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            await _repository.AddAsync(entity);
            return OResult as dynamic;
        }

            


        public async ValueTask Delete(Guid ContractId)
        {
            var spec = new Core.Entites.Inventories.Spceification.ReadByIdSpceifecation(ContractId);
            if (ContractId == Guid.Empty)
            {
                throw new ResultException("Invalid contract ID",((int)HttpStatusCode.BadRequest));
            }
            var entity = await _repository.FirstOrDefaultAsync(spec);
            if (entity == null)
            {
                throw new KeyNotFoundException("Contract not found");
            }
            await _repository.DeleteAsync(entity);
        }

        public async ValueTask<List<TResponse>> GetAll()
        {
            var entities = await _repository.ListAsync();
            var OResult =  entities.Select(e => new InventoryContract(e.InventoryId, e.Name, e.Quantity, e.Location)).ToList();
            return OResult as dynamic;
        }
        

        public async ValueTask<TResponse> GetById(Guid ContractId)
        {
            if (ContractId == Guid.Empty)
            {
                throw new ResultException("Invalid contract ID", ((int)HttpStatusCode.BadRequest));
            }
            var spec = new Core.Entites.Inventories.Spceification.ReadByIdSpceifecation(ContractId);
            var entity = await _repository.FirstOrDefaultAsync(spec);
            if (entity == null)
            {
                throw new ResultException("Contract not found", ((int)HttpStatusCode.NotFound));
            }
            return new InventoryContract(entity.InventoryId, entity.Name, entity.Quantity, entity.Location) as dynamic;
        }

        public ValueTask<List<TResponse>> GetByParentId(Guid parentId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResponse> GetSingleByParentId(Guid parentId, Guid id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask Update(TRequest contract, Guid id)
        {
            var spec = new Core.Entites.Inventories.Spceification.ReadByIdSpceifecation(id);
            if (contract == null || id == Guid.Empty)
            {
                throw new ResultException("Invalid contract or ID", ((int)HttpStatusCode.BadRequest));
            }
            var oContract = contract as InventoryOperationsContract;
            var oData =await _repository.FirstOrDefaultAsync(spec);
            if (oData == null)
            {
                throw new ResultException("Contract not found", ((int)HttpStatusCode.NotFound));
            }
            oData.Name = oContract.Name;
            oData.Quantity = oContract.Quantity;
            oData.Location = oContract.Location;
            oData.LastUpdated = oContract.LastUpdated;
            await _repository.UpdateAsync(oData); 
        }

        public ValueTask UpdateParentId(Guid ContractId, Guid parentId)
        {
            throw new NotImplementedException();
        }
    }
}
