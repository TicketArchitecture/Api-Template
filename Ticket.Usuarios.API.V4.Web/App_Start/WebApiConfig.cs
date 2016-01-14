using System.Web.Http;

namespace Ticket.Usuarios.API.V4.Web
{
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Remove XML formatter.
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "Usuario_ID",
                routeTemplate: "usuarios/v4/{id}",
                defaults: new { controller = "UsuariosV4", action = "GetById" }
            );

            config.Routes.MapHttpRoute(
               name: "Busca_Usuarios",
               routeTemplate: "usuarios/v4/",
               defaults: new { controller = "UsuariosV4"}
           );

            config.Routes.MapHttpRoute(
               name: "Cria_Usuario_Complexo",
               routeTemplate: "usuarios/v5/",
               defaults: new { controller = "UsuariosV5" }
           );


        }
    }
}
