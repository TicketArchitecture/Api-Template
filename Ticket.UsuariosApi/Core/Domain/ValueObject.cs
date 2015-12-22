using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.UsuariosApi.Core.Domain
{
    public abstract class ValueObject<T> : BusinessValidator
    {
        public abstract bool SameValueAs(T other);
    }
}
