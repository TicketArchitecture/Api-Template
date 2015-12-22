using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.UsuariosApi.Core.Domain
{
    public class BusinessValidator
    {
        protected void Validate(Dictionary<string,string> erros)
        {
            if (erros != null & erros.Count > 0)
                throw new BusinessException(erros);
        }
    }
}
