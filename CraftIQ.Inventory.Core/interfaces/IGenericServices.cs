using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Services.CategoriesImplemention
{
    internal interface IGenericServices<TRequest,TResponse>
    {
        ValueTask<TResponse> Create(TRequest contract);
        ValueTask<TResponse> Update(TRequest contract, Guid id);
        ValueTask<TResponse> GetById(Guid ContractId);
        ValueTask<List<TResponse>> GetAll();
        ValueTask<List<TResponse>> GetByParentId(Guid parentId);
        ValueTask UpdateParentId(Guid ContractId, Guid parentId);
        ValueTask<TResponse> GetSingleByParentId(Guid parentId, Guid id);
        ValueTask Delete(Guid ContractId); 
    }
}
