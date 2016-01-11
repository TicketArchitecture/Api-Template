using System.Threading;
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

            if (_log.IsDebugEnabled)
            {
                GlobalContext.Properties["GCAllocatedBytesHelper"] = new GCAllocatedBytesHelper();
                GlobalContext.Properties["AverageCPUUsageHelper"] = new AverageCPUUsageHelper();
            }

            _log.Info("Configurado");
            _log.Debug("Configurado em DEBUG");

            GlobalConfiguration.Configure(WebApiConfig.Register);
            NHibernate.Glimpse.Plugin.RegisterSessionFactory(Database.Factory);

            //se algum dia realmente precisarmos de um container....
            //APIUnityConfig.RegisterComponents();

#if DEBUG
           // DebugMigrationDBConfig.MigrateDatabase("Data Source=|DataDirectory|demo.db;Version=3");
#endif
        }
        protected void Application_BeginRequest()
        {
            _log.Error("erro no beginRequest");
            Database.OpenSession();
        }

        protected void Application_EndRequest()
        {
            Database.CloseSession();
        }
    }
}
