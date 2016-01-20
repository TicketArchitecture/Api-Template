using System;
using System.Threading;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using log4net;
using Ticket.API.Shared;
using Ticket.API.Shared.Filters;
using Ticket.API.Shared.Logging;

namespace Ticket.Usuarios.API.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(WebApiApplication));
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log.Info("inicio aplicação");

            if (_log.IsDebugEnabled)
            {
                DebugSetup.On();
            }

            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new ExceptionLoggingFilterAttribute());
            GlobalConfiguration.Configuration.MessageHandlers.Add(new DebugLogMessageFilter());

            NHibernate.Glimpse.Plugin.RegisterSessionFactory(Database.Factory);

            //se algum dia realmente precisarmos de um container....
            //APIUnityConfig.RegisterComponents();

#if DEBUG
            //habilite para criar o db schema do zero
            // DebugMigrationDBConfig.MigrateDatabase("Data Source=|DataDirectory|demo.db;Version=3");
#endif
            _log.Info("Configurado");

        }
        protected void Application_BeginRequest()
        {
            if (_log.IsDebugEnabled)
            {
                Request.RequestContext.HttpContext.Items["InicioRequest"] = DateTime.Now;
                log4net.ThreadContext.Stacks["RequestId"].Push(System.Guid.NewGuid().ToString("N"));
                
                //TODO: mapear todas as informações importantes de Request
                _log.Debug( Request.HttpMethod + " size: " + Request.TotalBytes);
            }

            Database.OpenSession();
        }

        protected void Application_EndRequest()
        {
            Database.CloseSession();

            if (_log.IsDebugEnabled)
            {
                var obj = Request.RequestContext.HttpContext.Items["InicioRequest"];
                if (obj != null)
                {
                    var inicioRequest = (DateTime)Request.RequestContext.HttpContext.Items["InicioRequest"];
                    var duracaoRequest = DateTime.Now.Subtract(inicioRequest);
                    _log.Debug("duracao (ms): " + duracaoRequest.TotalMilliseconds);
                }
                _log.Debug(Response.StatusCode);
                log4net.ThreadContext.Stacks["RequestId"].Pop();
            }
        }
    }
}
