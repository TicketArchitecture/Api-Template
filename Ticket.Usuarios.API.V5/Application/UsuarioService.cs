using System;
using log4net;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V5.Application.Commands;
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

            //Erro de negócio tem duas origens:
            //1. invariants (regras de negócio) da própria Entidade de negócio
            //2. db constraint: veja como ela é gerada em Ticket.API.Shared.NH.SQL*ExceptionConverter
            catch (BusinessException e)
            {
                _log.Debug(e);
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
