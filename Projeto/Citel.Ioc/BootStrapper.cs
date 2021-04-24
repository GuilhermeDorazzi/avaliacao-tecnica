using Citel.Core.Repositories;
using Citel.Core.Service;
using Citel.Core.Service.Interfaces;
using Citel.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Citel.Ioc
{
    public static class BootStrapper
    {
        public static void InjetarDependencias(IServiceCollection services, IConfiguration configuration)
        {
            RegistrarServicesRepository(services);
        }

        private static void RegistrarServicesRepository(IServiceCollection services)
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
