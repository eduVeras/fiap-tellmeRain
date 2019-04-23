using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Fiap.TellMeRain.Api.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configurações do swagger para documentação do projeto a partir de um endpoint.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "",
                    Version = "",
                    Description = ""
                });
                c.IgnoreObsoleteActions();
                c.ResolveConflictingActions(xx => xx.FirstOrDefault());
                //c.IncludeXmlComments(xmlPath);
                c.IgnoreObsoleteProperties();
            });
        }
    }
}
