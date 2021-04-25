using Citel.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Citel.Api
{
    public class Startup
    {
        /// <summary>
        /// Objeto para acesso ao arquivo de configurações, pode ser acessado de forma estatica "Startup.Configuration"
        /// </summary>
        internal static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // injecao de dependencia
            InjetarDependencias(services);

            services.AddCors();

            services.AddMvcCore(config =>
            {
                config.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseMvc();

        }

        private void InjetarDependencias(IServiceCollection services)
        {
            BootStrapper.InjetarDependencias(services, Configuration);
        }
    }
}
