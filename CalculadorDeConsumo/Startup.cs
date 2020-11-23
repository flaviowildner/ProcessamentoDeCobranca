using System;
using System.IO;
using System.Reflection;
using CalculadorDeConsumo.Infrastructure.Factories;
using CalculadorDeConsumo.MicroservicesCommunication.Clientes;
using CalculadorDeConsumo.MicroservicesCommunication.Cobrancas;
using CalculadorDeConsumo.Services;
using CalculadorDeConsumo.Services.ConsumptionCalculator;
using CalculadorDeConsumo.Swagger;
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
                c.DocumentFilter<SwaggerFilters>();
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IClienteCommunication>(provider =>
                new HttpClienteCommunication(Configuration["ClientesBaseAddress"]));
            
            services.AddScoped<ICobrancaCommunication>(provider =>
                new HttpCobrancaCommunication(Configuration["CobrancasBaseAddress"]));

            services.AddScoped<ICobrancaRegistrationService, CobrancaRegistrationService>();
            services.AddScoped<IConsumptionCalculator, CpfBasedConsumptionCalculator>();
            services.AddScoped<ICobrancaFactory, CobrancaFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalculadorDeConsumo v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}