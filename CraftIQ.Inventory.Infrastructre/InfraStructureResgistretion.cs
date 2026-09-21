using CraftIQ.Inventory.Infrastructre.Data;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Infrastructre
{
    public static class InfraStructureResgistretion
    {
        public static void AddInventoryDbContext(this IServiceCollection services, string connectionString) => services.AddDbContext<AppContextDb>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        public static void AddInventoryRepository(this IServiceCollection services)
        {
            services.AddScoped ( typeof(IRepository<>), typeof(InventoryRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(InventoryRepository<>));

        }
    }
}
