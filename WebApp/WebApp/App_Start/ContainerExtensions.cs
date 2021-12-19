using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;

namespace WebApp
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {

            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClientesService, ClientesService>();
            services.AddTransient<IProductosService, ProductosService>();
            services.AddTransient<IPedidosService, PedidosService>();
            return services;
        }
    }
}
