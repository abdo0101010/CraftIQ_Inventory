using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Categories.Specification;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;

using System.Net;
using System.Linq;
using CraftIQ.Inventory.Services.Factories;

namespace CraftIQ.Inventory.Services.CategoriesImplemention
{
    public class CategoriesServices<TRequest, TResponse>(IRepository<Category> repository) : IGenericServices<TRequest, TResponse>
    {
        IRepository<Category> _repository = repository;

        public async ValueTask<TResponse> Create(TRequest contract)
        {
            var OContract = contract as CategoriesOperationContract;
            var OData = new Category(OContract!.Name, OContract.Description);
            var OResult = await _repository.AddAsync(OData);
            return new CategoriesOperationContract(OResult.Name, OResult.Description)as dynamic;
            ;
        }

        public async ValueTask Delete(Guid ContractId)
        {
            var oReadByIdSpec = new ReadByIdSpecification(ContractId);
            var oResult = await _repository.FirstOrDefaultAsync(oReadByIdSpec);
            if (oResult != null)
                await _repository.DeleteAsync(oResult);
            else throw new ResultException("You can't delete object that is not exit.", (int)HttpStatusCode.Forbidden);

        }

        public async ValueTask<List<TResponse>> GetAll()
        {
            var oReadSpec = new ReadSpecification();
            var oData = await _repository.ListAsync(oReadSpec);
            if (oData != null && oData.Count > 0)
            {
                var oResult = oData.Select(o => new CategoriesContract(o. CategoryId,
                                                                       o.Name,
                                                                       o.Description,
                                                                       o.CreatedBY,
                                                                       o.ModifiedBy,
                                                                       o.CreatedOn,
                                                                       o.ModifiedOn)).ToList();
                return oResult as dynamic;
            }
            else return new List<CategoriesContract>() as dynamic;

        }
        }

        public ValueTask<TResponse> GetById(Guid ContractId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<TResponse>> GetByParentId(Guid parentId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResponse> GetSingleByParentId(Guid parentId, Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TResponse> Update(TRequest contract, Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask UpdateParentId(Guid ContractId, Guid parentId)
        {
            throw new NotImplementedException();
        }
        //public async ValueTask<CategoriesOperationContract> CreateCategory(CategoriesOperationContract category)
        //{
        //    var OData=new  Category(category.Name, category.Description);
        //    var OResult = await _repository.AddAsync(OData);
        //    return new CategoriesOperationContract(OResult.Name,OResult.Description);


        //}

        //public async ValueTask DeleteCategoryByCategoryId(Guid categoryId)
        //{
        //    var OReadByIdSpec= new ReadByIdSpecification(categoryId);
        //    var OData = await _repository.FirstOrDefaultAsync(OReadByIdSpec);
        //    if (OData == null)
        //    {
        //        throw new ResultException("Category not found",(int)HttpStatusCode.NotFound);
        //    }

        //        await _repository.DeleteAsync(OData);

        //}

        //public async ValueTask<List<CategoriesContract>> GetAllCategories()
        //{
        //    var OReadAllSpec = new ReadSpecification();
        //    var OData = await _repository.ListAsync(OReadAllSpec);
        //    if (OData == null)
        //    {
        //        throw new ResultException("No categories found", (int)HttpStatusCode.NotFound);
        //    }
        //    var OResult = OData.Select(c => new CategoriesContract(c.CategoryId, c.Name, c.Description, c.CreatedBY, c.ModifiedBy, c.CreatedOn, c.ModifiedOn)).ToList();
        //    return OResult;
        //}

        //public async ValueTask<CategoriesContract> GetCategoryByCategoryId(Guid categoryId)
        //{
        //    var OReadByIdSpec = new ReadByIdSpecification(categoryId);
        //    var OData = await _repository.FirstOrDefaultAsync(OReadByIdSpec);
        //    if(OData == null)
        //    {
        //        throw new ResultException("Category not found", (int)HttpStatusCode.NotFound);
        //    }
        //    var OResult = new CategoriesContract(OData.CategoryId, OData.Name, OData.Description, OData.CreatedBY, OData.ModifiedBy, OData.CreatedOn, OData.ModifiedOn);
        //    return OResult;

        //}

        //public async ValueTask UpdateCategory(CategoriesOperationContract category, Guid categoryId)
        //{
        //    var OReadByIdSpec = new ReadByIdSpecification(categoryId);
        //    var OData = await _repository.FirstOrDefaultAsync(OReadByIdSpec);
        //    if(OData == null)
        //    {
        //        throw new ResultException("Category not found", (int)HttpStatusCode.NotFound);
        //    }

        //    OData.Name=category.Name;
        //    OData.Description = category.Description;


        //    await _repository.UpdateAsync(OData);


        //}
    }
}
