using System;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V4.Application.Commands;
using Ticket.Usuarios.API.V4.Domain;
using Ticket.Usuarios.API.V4.Representations;

namespace Ticket.Usuarios.API.V4.Application
{
    public class UsuarioService : Contracts.IUsuarioService
    {

        public UsuarioRepresentation CriarNovoUsuario(NovoUsuarioCommand usuario)
        {
            //primeiro garantimos as regras de negócio ao instanciar novo usuário.
            //qualquer erro de negócio será informado para as camadas superiores como uma BusinessException
            var novoUsuario = new UsuarioDadosMinimos(usuario.Nome, usuario.Email, usuario.AceitoMkt);
            UsuarioRepresentation usuarioCriado = null;
            try
            {
              //  durante a gravação deixamos as constraints do DB agirem.
                novoUsuario.Id = (int)Database.Session.Save(novoUsuario);

                //as camadas superiores (WEB/API) devem sempre receber uma representação web, jamais os objetos de domínio
                usuarioCriado = Database.Session.Get<UsuarioRepresentation>(novoUsuario.Id);
            }
            //TODO: separar os tipos de erros: negócio e infra
            catch (BusinessException e)
            {
                //TODO: Log
                throw;
            }
            catch (Exception e)
            {
                //TODO: Log
                BusinessExceptionCreator.ThrowBusinessExceptionWithResourcesMessage("Erro.Inesperado.Insert");
            }

            return usuarioCriado;
        }
    }
}
