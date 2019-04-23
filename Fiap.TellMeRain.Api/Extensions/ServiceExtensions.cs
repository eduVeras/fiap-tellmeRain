using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Fiap.TellMeRain.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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


        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            /*
             * DI Configurações
             */

            /*
             * Database
             */
            var strin = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RainContext>(options => options.UseSqlServer(strin, builder => 
                builder.EnableRetryOnFailure(3,TimeSpan.FromSeconds(5),null)));


        }
    }
}
