using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CalculadorDeConsumo.Swagger
{
    public class SwaggerFilters : IDocumentFilter
    {
        private static readonly string[] IgnoredControllers = {"/api/clientes", "/api/cobrancas"};
        private static readonly string[] IgnoredSchemas = {"ClienteDTO", "CobrancaDTO"};

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            IgnoredControllers
                .ToList()
                .ForEach(ignoredController => swaggerDoc.Paths.Remove(ignoredController));

            IgnoredSchemas
                .ToList()
                .ForEach(schema => swaggerDoc.Components.Schemas.Remove(schema));
        }
    }
}