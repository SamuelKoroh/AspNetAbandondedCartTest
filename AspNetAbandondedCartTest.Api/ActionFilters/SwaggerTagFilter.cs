using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using IDocumentFilter = Swashbuckle.Swagger.IDocumentFilter;

namespace AspNetAbandondedCartTest.Api.ActionFilters
{
    public class SwaggerTagFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (var apiDescription in apiExplorer.ApiDescriptions)
            {
                if (!apiDescription.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<SwaggerTagAttribute>().Any() && !apiDescription.ActionDescriptor.GetCustomAttributes<SwaggerTagAttribute>().Any()) continue;
                var route = "/" + apiDescription.Route.RouteTemplate.TrimEnd('/');
                swaggerDoc.paths.Remove(route); 
            }
        }
    }
}
