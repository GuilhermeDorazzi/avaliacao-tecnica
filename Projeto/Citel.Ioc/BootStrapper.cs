using Citel.Core.Repositories;
using Citel.Core.Service;
using Citel.Core.Service.Interfaces;
using Citel.Data.Repositories;
using Citel.Data.Repositories.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Citel.Ioc
{
    public static class BootStrapper
    {
        public static void InjetarDependencias(IServiceCollection services, IConfiguration configuration)
        {
            RegistrarDependenciasBancoDados(services, configuration);
            RegistrarServicesRepository(services);
        }

        private static void RegistrarDependenciasBancoDados(IServiceCollection services, IConfiguration configuration)
        {
            // Dicionario de conexoes
            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.MySqlDbConnection, configuration.GetConnectionString("ConexaoMySql") }
            };

            // Injeta o Dicionario de conexoes
            services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);

            // Injeta a fabrica de conexoes
            services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();
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
