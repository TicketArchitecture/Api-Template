using System;
using log4net;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V5.Application.Commands;
using Ticket.Usuarios.API.V5.Domain;
using Ticket.Usuarios.API.V5.Representations;

namespace Ticket.Usuarios.API.V5.Application
{
    public class UsuarioService
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(UsuarioService).FullName);

        public UsuarioRepresentation CriarNovoUsuarioComplexo(NovoUsuarioCompletoCommand cmd)
        {
            //primeiro garantimos as regras de negócio ao instanciar novo usuário.
            //qualquer erro de negócio será informado para as camadas superiores como uma BusinessException
            var novoUsuario = EntitiesFactories.UsuarioCompletoFactory.Create(cmd);

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
                _log.Error(e);
                throw;
            }
            catch (Exception e)
            {
                _log.Error(e);
                BusinessExceptionCreator.ThrowBusinessExceptionWithResourcesMessage("ErroInesperadoInsert");
            }

            return usuarioCriado;
        }
    }
}
