using System.Web.Http;
using Ticket.API.Shared;

namespace Ticket.Usuarios.API.V4.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            NHibernate.Glimpse.Plugin.RegisterSessionFactory(Database.Factory);

            //se algum dia realmente precisarmos de um container....
            //APIUnityConfig.RegisterComponents();

#if DEBUG
            DebugMigrationDBConfig.MigrateDatabase("Data Source=|DataDirectory|demo.db;Version=3");
#endif
        }
        protected void Application_BeginRequest()
        {
            Database.OpenSession();
        }

        protected void Application_EndRequest()
        {
            Database.CloseSession();
        }
    }
}
