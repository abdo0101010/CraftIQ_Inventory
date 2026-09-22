using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.interfaces
{
    public interface ICateegoriesServices
    {
        public  ValueTask<List<CategoriesContract>> GetAllCategories();
        public  ValueTask<CategoriesContract> GetCategoryByCategoryId(Guid categoryId);

        public  ValueTask<CategoriesOperationContract> CreateCategory(CategoriesOperationContract category);

        public  ValueTask UpdateCategory(CategoriesOperationContract category, Guid categoryId);

        public ValueTask DeleteCategoryByCategoryId(Guid categoryId);
    }
}
