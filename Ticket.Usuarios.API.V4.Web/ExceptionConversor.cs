using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.Usuarios.API.V4.Web
{
    static class ExceptionConversor
    {

        public static void ComplementModelStateErrors(ModelStateDictionary state, BusinessException exception)
        {
            foreach (var error in exception.Data as IDictionary<string, string>)
                state.AddModelError(error.Key,error.Value); 
        }
    }
}
