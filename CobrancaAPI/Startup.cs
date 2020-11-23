using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AutoMapper;
using CobrancaAPI.Models.Entity;
using CobrancaAPI.Persistence.Repositories;
using CobrancaAPI.Persistence.Repositories.MongoDB.FilterStrategies;
using CobrancaAPI.Services;
using CobrancaAPI.Settings;
using CobrancaAPI.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CobrancaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CobrancaAPI", Version = "v1"});
                c.DocumentFilter<SwaggerFilters>();
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.Configure<CobrancaDatabaseSettings>(Configuration.GetSection(nameof(CobrancaDatabaseSettings)));
            services.AddSingleton<ICobrancaDatabaseSettings, CobrancaDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CobrancaDatabaseSettings>>().Value);

            services.AddScoped<ICobrancaRepository>(provider =>
            {
                var mongoFilterDefinitionStrategies =
                    new Dictionary<string, IMongoFilterDefinitionStrategy<Cobranca>>
                    {
                        {"cpf", new CpfMongoFilterDefinitionStrategy()},
                        {"mes", new MesMongoFilterDefinitionStrategy()}
                    };

                return new MongoCobrancaRepository(provider.GetService<ICobrancaDatabaseSettings>(),
                    mongoFilterDefinitionStrategies);
            });

            services.AddScoped<ICobrancaService, CobrancaService>();

            services.AddAutoMapper(typeof(Startup));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CobrancaAPI v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}