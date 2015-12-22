using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NHibernate;
using Ticket.Usuarios.API.Shared;

namespace Ticket.API.Shared.Attributes
{
    //seguindo isto: http://weblogs.asp.net/srkirkland/making-asp-net-mvc-actions-be-transactional-by-default
    //Recebe o prefixo MVC para deixar claro a especificidade, já que o WEB API usaria System.Web.Http.Filters.ActionFilterAttribute.
    //além disso, os overrides do WEB API recebem HttpActionExecutedContext como objeto.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class APIUseTransactionsByDefaultAttribute : ActionFilterAttribute
    {
        private bool _delegateTransactionSupport;

        public override void OnActionExecuting(HttpActionContext filterContext)

        {
            _delegateTransactionSupport = DelegarTransacaoParaOutroFiltro(filterContext);

            if (_delegateTransactionSupport) return;

            Database.Session.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            if (_delegateTransactionSupport) return;

            if (Database.Session.Transaction.IsActive)
            {
                if (filterContext.Exception == null)
                {
                    Database.Session.Transaction.Commit();
                }
                else
                {
                    Database.Session.Transaction.Rollback();
                }
            }
        }

        private static bool DelegarTransacaoParaOutroFiltro(HttpActionContext context)

        {

            var attrs = context.ActionDescriptor.GetCustomAttributes<APITransactionalActionBaseAttribute>(true);



            return attrs.Count > 0;

        }
    }
    public class APITransactionalActionBaseAttribute : ActionFilterAttribute
    {



    }
}
