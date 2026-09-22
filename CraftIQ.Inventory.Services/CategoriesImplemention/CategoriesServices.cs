using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Categories.Specification;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;

using System.Net;
using System.Linq;

namespace CraftIQ.Inventory.Services.CategoriesImplemention
{
    public class CategoriesServices(IRepository<Category> repository) : ICateegoriesServices
    {
        private readonly IRepository<Category> _repository = repository;
        public async ValueTask<CategoriesOperationContract> CreateCategory(CategoriesOperationContract category)
        {
            var OData=new  Category(category.Name, category.Description);
            var OResult = await _repository.AddAsync(OData);
            return new CategoriesOperationContract(OResult.Name,OResult.Description);


        }

        public async ValueTask DeleteCategoryByCategoryId(Guid categoryId)
        {
            var OReadByIdSpec= new ReadByIdSpecification(categoryId);
            var OData = await _repository.FirstOrDefaultAsync(OReadByIdSpec);
            if (OData == null)
            {
                throw new ResultException("Category not found",(int)HttpStatusCode.NotFound);
            }
            
                await _repository.DeleteAsync(OData);
            
        }

        public async ValueTask<List<CategoriesContract>> GetAllCategories()
        {
            var OReadAllSpec = new ReadSpecification();
            var OData = await _repository.ListAsync(OReadAllSpec);
            if (OData == null)
            {
                throw new ResultException("No categories found", (int)HttpStatusCode.NotFound);
            }
            var OResult = OData.Select(c => new CategoriesContract(c.CategoryId, c.Name, c.Description, c.CreatedBY, c.ModifiedBy, c.CreatedOn, c.ModifiedOn)).ToList();
            return OResult;
        }

        public async ValueTask<CategoriesContract> GetCategoryByCategoryId(Guid categoryId)
        {
            var OReadByIdSpec = new ReadByIdSpecification(categoryId);
            var OData = await _repository.FirstOrDefaultAsync(OReadByIdSpec);
            if(OData == null)
            {
                throw new ResultException("Category not found", (int)HttpStatusCode.NotFound);
            }
            var OResult = new CategoriesContract(OData.CategoryId, OData.Name, OData.Description, OData.CreatedBY, OData.ModifiedBy, OData.CreatedOn, OData.ModifiedOn);
            return OResult;

        }

        public async ValueTask UpdateCategory(CategoriesOperationContract category, Guid categoryId)
        {
            var OReadByIdSpec = new ReadByIdSpecification(categoryId);
            var OData = await _repository.FirstOrDefaultAsync(OReadByIdSpec);
            if(OData == null)
            {
                throw new ResultException("Category not found", (int)HttpStatusCode.NotFound);
            }

            OData.Name=category.Name;
            OData.Description = category.Description;


            await _repository.UpdateAsync(OData);


        }
    }
}
