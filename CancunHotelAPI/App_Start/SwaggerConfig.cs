namespace CancunHotelAPI.App_Start
{

using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

    /// <summary>
    /// Represents configuration for Swagger and SwaggerUI
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Configures Swagger and SwaggerUI.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);

            configuration.EnableSwagger("docs/{apiVersion}/OpenAPI", c =>
            {
                //Tell swagger to generate documentation based on the XML doc file output from msbuild
                c.IncludeXmlComments(Path.Combine(baseDirectory, "bin", "CancunHotelAPI.XML"));
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.SingleApiVersion("1.0", "Cancun Hotel API")
                    // El titulo debe venir de algun tipo de configuración
                    .Description("API to book Cancun hotel")
                    .Contact(cc => cc
                        .Name("Juan Sebastian")                            
                        .Email("dev.sebastianm@gmail.com"));                
            }).EnableSwaggerUi();

        }
    }
}