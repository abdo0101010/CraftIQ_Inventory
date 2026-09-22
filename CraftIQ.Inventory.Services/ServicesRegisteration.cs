using CraftIQ.Inventory.Core.interfaces;
using CraftIQ.Inventory.Services.CategoriesImplemention;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Inventory.Services
{
    public static class ServicesRegisteration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICateegoriesServices, CategoriesServices>();
        }
    }
}
