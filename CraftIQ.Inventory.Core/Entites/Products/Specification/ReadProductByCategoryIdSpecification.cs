using Ardalis.Specification;
using CraftIQ.Inventory.Core.Entites.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Core.Entites.Products.Specification
{
    public class ReadProductByCategoryIdSpecification : Specification<Category>
    {
        public ReadProductByCategoryIdSpecification(Guid CategoryId)
        {
            Query.Where(c => c.CategoryId == CategoryId).Include(p => p.Products.Select(p=>p.CategoryId==CategoryId));
        }
    }
}
