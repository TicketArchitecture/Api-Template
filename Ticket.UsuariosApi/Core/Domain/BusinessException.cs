using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.UsuariosApi.Core.Domain
{
    public class BusinessException : Exception
    {
        private IDictionary<string, string> _errors = new Dictionary<string, string>();
        public BusinessException(IDictionary<string,string> errors)
        {
            _errors= errors;

        }

        public override IDictionary Data
        {
            get
            {
                return _errors as IDictionary;
            }
        }
    }
}
