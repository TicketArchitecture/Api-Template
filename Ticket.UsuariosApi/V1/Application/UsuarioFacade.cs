using System;
using Ticket.UsuariosApi.Core.Data.NH.Repositories;
using Ticket.UsuariosApi.Core.Domain;
using Ticket.UsuariosApi.V1.Representations;

namespace Ticket.UsuariosApi.V1.Application.Application
{
    public class UsuarioFacade : Contracts.IUsuarioFacade
    {
        private readonly IReadOnlyRepository<UsuarioRepresentation> _usuarioV1Repository;

        public UsuarioFacade(IReadOnlyRepository<UsuarioRepresentation> usuarioV1Repository)
        {
            _usuarioV1Repository = usuarioV1Repository;
        }


        public UsuarioRepresentation Create(UsuarioRepresentation resource)
        {

            var factory = new Factories.UsuarioFactory();
            try
            {
                
                var entity = factory.Create(resource);
                //_usuarioRepository.save(entity);

            }
            catch (BusinessException e)
            {
                //log it.
                throw;
            }
            catch (Exception e)
            {
                //log it.
                throw;

            }

            return resource;
        }

        public UsuarioRepresentation FindById(int id)
        {
            var resource = _usuarioV1Repository.FindBy(id);
            return resource;
        }
    }
}
