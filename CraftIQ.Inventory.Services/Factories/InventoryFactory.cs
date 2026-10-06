using CraftIQ.Inventory.Core.Entites.Categories;
using CraftIQ.Inventory.Core.Entites.Products;
using CraftIQ.Inventory.Core.Entites.Transactions;
using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Services.CategoriesImplemention;
using CraftIQ.Inventory.Services.InventoriesImplemention;
using CraftIQ.Inventory.Services.ProductsImplemention;
using CraftIQ.Inventory.Services.TransactionImplemention;
using huzcodes.Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Services.Factories
{
    public class InventoryFactory<TRequest, TResponse>(IRepository<Category> category, IRepository<Product> product,IRepository<Inventory.Core.Entites.Inventories.Inventory> inventory, IRepository<Transaction> transaction)
    {

        private readonly IRepository<Category> _category = category;
        private readonly IRepository<Product> _product = product;
        private readonly IRepository<Inventory.Core.Entites.Inventories.Inventory> _inventory = inventory;
        private readonly IRepository<Transaction> _transaction = transaction;

        public IGenericServices<TRequest, TResponse> Build(string key)
        {
            switch (key)
            {
                case nameof(Category):
                    return new CategoriesServices<TRequest, TResponse>(_category);
                case nameof(Product):
                    return new ProductService<TRequest, TResponse>(_product, _category, _inventory);
                case nameof(Inventory.Core.Entites.Inventories.Inventory):
                    return new InventoryServices<TRequest, TResponse>(_inventory);
                case nameof(Transaction):
                    return new TransactionService<TRequest, TResponse>(_transaction);

                default: return null!;
            }

        }
    }
}
