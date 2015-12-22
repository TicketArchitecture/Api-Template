using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.UsuariosApi.V1.Application.Contracts
{
    interface IUsuarioFactory
    {
        Domain.Usuario Create(Representations.UsuarioRepresentation resource);

    }
}
