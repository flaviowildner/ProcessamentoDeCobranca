using CalculadorDeConsumo.Communication;
using CalculadorDeConsumo.Infrastructure.Factories;
using CalculadorDeConsumo.Services;
using CalculadorDeConsumo.Services.CalculadorDeConsumo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CalculadorDeConsumo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CalculadorDeConsumo", Version = "v1"});
            });

            services.AddScoped<IAPICommunication, HttpAPICommunication>();
            services.AddScoped<ICalculadorDeConsumoService, CalculadorDeConsumoService>();
            services.AddScoped<ICalculadorDeConsumo, CalculadorDeConsumoBaseadoNoCPF>();
            services.AddScoped<ICobrancaFactory, CobrancaFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalculadorDeConsumo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}