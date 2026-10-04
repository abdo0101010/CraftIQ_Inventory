using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Services.CategoriesImplemention;
using CraftIQ.Inventory.Services.InventoriesImplemention;
using CraftIQ.Inventory.Services.ProductsImplemention;
using huzcodes.Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Services.Factories
{
    public class InventoryFactory<TRequest, TResponse>(IRepository<Category> category, IRepository<Product> product,IRepository<Inventory.Core.Entites.Inventories.Inventory> inventory)
    {

        private readonly IRepository<Category> _category = category;
        private readonly IRepository<Product> _product = product;
        private readonly IRepository<Inventory.Core.Entites.Inventories.Inventory> _inventory = inventory;

        public IGenericServices<TRequest, TResponse> Build(string key)
        {
            switch (key)
            {
                case nameof(Category):
                    return new CategoriesServices<TRequest, TResponse>(_category);
                case nameof(Product):
                    return new ProductService<TRequest, TResponse>(_product, _category);
                case nameof(Inventory.Core.Entites.Inventories.Inventory):
                    return new InventoryServices<TRequest, TResponse>(_inventory);  

                default: return null!;
            }

        }
    }
}
