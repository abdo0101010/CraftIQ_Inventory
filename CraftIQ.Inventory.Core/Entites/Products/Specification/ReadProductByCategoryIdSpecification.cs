using Ardalis.Specification;
using CraftIQ.Inventory.Core.Entites.Categories;
using System;

namespace CraftIQ.Inventory.Core.Entites.Products.Specification
{
    public class ReadProductByCategoryIdSpecification : Specification<Category>
    {
        public ReadProductByCategoryIdSpecification(Guid categoryId)
        {
            Query.Where(c => c.CategoryId == categoryId)
                 .Include(c => c.Products); 
        }
    }
}