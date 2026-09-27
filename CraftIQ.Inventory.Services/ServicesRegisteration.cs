using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Services.CategoriesImplemention;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Shared.Contracts.Categories;
using Microsoft.Extensions.DependencyInjection;


namespace CraftIQ.Inventory.Services
{
    public static class ServicesRegisteration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(InventoryFactory<,>));
            services.AddScoped<IGenericServices<CategoriesOperationContract, CategoriesContract>, CategoriesServices<CategoriesOperationContract, CategoriesContract>>();
        }
    }
}
