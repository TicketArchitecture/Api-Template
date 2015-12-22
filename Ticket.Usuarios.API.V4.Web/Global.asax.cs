using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Ticket.Usuarios.API.Shared;

namespace Ticket.Usuarios.API.V4.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            NHibernate.Glimpse.Plugin.RegisterSessionFactory(Database.Factory);
            //ContextSessionBuilder.Initialize();
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
