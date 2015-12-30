using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.Usuarios.API.V4.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Usuario_ID",
                routeTemplate: "usuarios/v4/{id}",
                defaults: new { controller = "Usuarios", action = "GetById" }
            );
            config.Routes.MapHttpRoute(
               name: "Busca_Usuarios",
               routeTemplate: "usuarios/v4/",
               defaults: new { controller = "Usuarios", action = "Search" }
           );
          
        }
    }
}
