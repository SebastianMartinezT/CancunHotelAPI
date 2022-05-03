namespace CancunHotelAPI
{
    using Owin;    
    using CancunHotelAPI.App_Start;
    using System.Web.Http;
    using System.Configuration;
    using AutoMapper;
    using CancunHotel.Service.AppService;

    /// <summary>
    /// Represents the entry point into an application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Specifies how the ASP.NET application will respond to individual HTTP request.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {


            HttpConfiguration configuration = new HttpConfiguration();

            RouteConfig.Configure(configuration);
            
            SwaggerConfig.Configure(configuration);


            app.UseWebApi(configuration);
            MappingProfile map = new MappingProfile();
            map.Iniciar();
        }
    }
}