using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ClienteAPI
{
    public class SwaggerFilters : IDocumentFilter
    {
        private static readonly string[] IgnoredControllers = {"/api/clientes"};
        private static readonly string[] IgnoredSchemas = {"ClienteDTO"};

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