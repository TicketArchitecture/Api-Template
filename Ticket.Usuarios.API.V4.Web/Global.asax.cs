using System.Web.Http;
using log4net;
using Ticket.API.Shared;
using Ticket.API.Shared.Logging;

namespace Ticket.Usuarios.API.V4.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(WebApiApplication));
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.GlobalContext.Properties["GCAllocatedBytesHelper"] = new GCAllocatedBytesHelper();
            _log.Info("Configurado");

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
