using Ticket.Usuarios.API.V4.Application.Commands;
using Ticket.Usuarios.API.V4.Representations;

namespace Ticket.Usuarios.API.V4.Application.Contracts
{
    public interface IUsuarioService
    {
        UsuarioRepresentation CriarNovoUsuario(NovoUsuarioCommand usuario);
    }
}
