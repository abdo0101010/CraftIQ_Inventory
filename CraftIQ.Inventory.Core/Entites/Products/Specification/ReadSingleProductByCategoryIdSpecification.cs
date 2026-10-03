using Ardalis.Specification;
using CraftIQ.Inventory.Core.Entites.Categories;
using System;

namespace CraftIQ.Inventory.Core.Entites.Products.Specification
{
    public class ReadSingleProductByCategoryIdSpecification : Specification<Category>
    {
        public ReadSingleProductByCategoryIdSpecification(Guid CategoryId, Guid ProductId)
        {
            Query.Where(c => c.CategoryId == CategoryId)
                 .Include(c => c.Products.Where(p => p.ProductId == ProductId));
        }
    }
}