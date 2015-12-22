using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.UsuariosApi.V1.Application.Contracts
{
    public interface IUsuarioFacade
    {
        Representations.UsuarioRepresentation Create(Representations.UsuarioRepresentation resource);
        Representations.UsuarioRepresentation FindById(int id);

    }
}
