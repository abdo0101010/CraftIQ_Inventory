using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Services.CategoriesImplemention;
using huzcodes.Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Services.Factories
{
    public class InventoryFactory<TRequest, TResponse>(IRepository<Category> category, IRepository<Product> product)
    {

        private readonly IRepository<Category> _category = category;
        private readonly IRepository<Product> _product = product;

        public IGenericServices<TRequest, TResponse> Build(string key)
        {
            switch (key)
            {
                case nameof(Category):
                    return new CategoriesServices<TRequest, TResponse>(_category);
            }

        }
    }
}
