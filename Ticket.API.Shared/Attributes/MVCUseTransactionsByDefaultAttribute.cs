using System;
using System.Web.Mvc;

namespace Ticket.API.Shared.Attributes
{
    //seguindo isto: http://weblogs.asp.net/srkirkland/making-asp-net-mvc-actions-be-transactional-by-default
    //Recebe o prefixo MVC para deixar claro a especificidade, já que o WEB API usaria System.Web.Http.Filters.ActionFilterAttribute.
    //além disso, os overrides do WEB API recebem HttpActionExecutedContext como objeto.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MVCUseTransactionsByDefaultAttribute: ActionFilterAttribute
    {
        private bool _delegateTransactionSupport;


        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            _delegateTransactionSupport = ShouldDelegateTransactionSupport(filterContext);

            if (_delegateTransactionSupport) return;

            Database.Session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
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

        private static bool ShouldDelegateTransactionSupport(ActionExecutingContext context)

        {

            var attrs = context.ActionDescriptor.GetCustomAttributes(typeof(MVCTransactionalActionBaseAttribute), false);



            return attrs.Length > 0;

        }
    }

    public class MVCTransactionalActionBaseAttribute : ActionFilterAttribute

    {



    }
}
