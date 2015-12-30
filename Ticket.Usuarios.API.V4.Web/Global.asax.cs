using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.Usuarios.API.V4.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            NHibernate.Glimpse.Plugin.RegisterSessionFactory(Database.Factory);
            
            APIUnityConfig.RegisterComponents();


            // Configures container for ASP.NET MVC
            //DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(UnityConfig.Container));

            // Configures container for WebAPI
            //GlobalConfiguration.Configuration.DependencyResolver = new Microsoft.Practices.Unity.WWebApi.UnityDependencyResolver(UnityConfig.Container);


        }
        protected void Application_BeginRequest()
        {
            //ContextSessionBuilder.OpenSession();
            Database.OpenSession();

        }

        protected void Application_EndRequest()
        {
            //ContextSessionBuilder.CloseSession();
            Database.CloseSession();
        }

       

    }
}
