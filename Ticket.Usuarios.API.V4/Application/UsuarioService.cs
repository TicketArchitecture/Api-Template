using System;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V4.Application.Commands;
using Ticket.Usuarios.API.V4.Domain;

namespace Ticket.Usuarios.API.V4.Application
{
    public class UsuarioService : Contracts.IUsuarioService
    {

        public int CriarNovoUsuario(NovoUsuarioCommand usuario)
        {
            //primeiro garantimos as regras de negócio ao instanciar novo usuário.
            //qualquer erro de negócio será informado para as camadas superiores como uma BusinessException
            var novoUsuario = new UsuarioDadosMinimos(usuario.Nome, usuario.Email, usuario.AceitoMkt);
            var id = 0;
            try {
                //durante a gravação deixamos as constraints do DB agirem.
                id = (int)Database.Session.Save(novoUsuario);
            }
            //TODO: separar os tipos de erros: negócio e infra
            catch(Exception e)
            {
                if(e.InnerException != null)
                //se o erro for email duplicado....
                BusinessValidator.ThrowBusinessExceptionWithResourcesMessage("Usuario.Email.Duplicado");
            }

            return id;
        }
    }
}
