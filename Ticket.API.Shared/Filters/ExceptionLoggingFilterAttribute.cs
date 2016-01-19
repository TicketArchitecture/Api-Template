using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using log4net;
using log4net.Core;

namespace Ticket.API.Shared.Filters
{
    public class ExceptionLoggingFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ExceptionLoggingFilterAttribute));

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            _log.Error("unhandled exception", actionExecutedContext.Exception);

            //aqui alteramos para debug automaticamente na tentativa de prover informações
            //sem a necessidade de interação humana
            if (!_log.IsDebugEnabled)
            {
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            }

            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            _log.Error("unhandled exception", actionExecutedContext.Exception);

            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}
