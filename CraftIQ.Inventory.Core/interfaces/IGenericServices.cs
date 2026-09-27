

namespace CraftIQ.Inventory.Core.interfaces { 

    public interface IGenericServices<TRequest,TResponse>
    {
        ValueTask<TResponse> Create(TRequest contract);
        ValueTask Update(TRequest contract, Guid id);
        ValueTask<TResponse> GetById(Guid ContractId);
        ValueTask<List<TResponse>> GetAll();
        ValueTask<List<TResponse>> GetByParentId(Guid parentId);
        ValueTask UpdateParentId(Guid ContractId, Guid parentId);
        ValueTask<TResponse> GetSingleByParentId(Guid parentId, Guid id);
        ValueTask Delete(Guid ContractId); 
    }
}
