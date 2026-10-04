using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Services.CategoriesImplemention;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Services.InventoriesImplemention;
using CraftIQ.Inventory.Services.ProductsImplemention;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using CraftIQ.Inventory.Shared.Contracts.Inventories;
using CraftIQ.Inventory.Shared.Contracts.Products;
using Microsoft.Extensions.DependencyInjection;


namespace CraftIQ.Inventory.Services
{
    public static class ServicesRegisteration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(InventoryFactory<,>));
            services.AddScoped<IGenericServices<CategoriesOperationContract, CategoriesContract>, CategoriesServices<CategoriesOperationContract, CategoriesContract>>();
            services.AddScoped<IGenericServices<ProductOperationContract, ProductContract>, ProductService<ProductOperationContract, ProductContract>>();
            services.AddScoped<IGenericServices<InventoryOperationsContract, InventoryContract>, InventoryServices<InventoryOperationsContract, InventoryContract>>();

        }
    }
}
