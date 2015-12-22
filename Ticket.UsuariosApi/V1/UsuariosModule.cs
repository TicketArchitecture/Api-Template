using System;
using Nancy.Responses;

using Ticket.UsuariosApi.Core;
using Ticket.UsuariosApi.Core.Data.NH.Repositories;
using Ticket.UsuariosApi.V1.Application.Contracts;
using Ticket.UsuariosApi.V1.Representations;

namespace Ticket.UsuariosApi.V1
{
    public class UsuarioModule : Nancy.NancyModule
    {
        private readonly IReadOnlyRepository<UsuarioRepresentation> _userRepository;
        private readonly IUsuarioFacade _usuarioFacade;

        public UsuarioModule(IUsuarioFacade usuarioFacade, IReadOnlyRepository<UsuarioRepresentation> userRepo) : base("usuarios/v1")
        {
            _usuarioFacade = usuarioFacade;
            _userRepository = userRepo;

            Get["/{id}"] = parameters =>
            {
                JsonResponse response = null;
                
                if (String.IsNullOrEmpty(parameters.id))
                {

                    var error = new FriendlyErrorMessage("Bad Request", "Id inválido");
                    return new JsonResponse(error, new DefaultJsonSerializer()) { ContentType = "application/json", StatusCode = Nancy.HttpStatusCode.BadRequest };
                }
                try
                {
                    var id = Int32.Parse(parameters.id);

                    //var usuario = _usuarioFacade.Create(parameters.id);// new UsuarioResource();// { cnpj = parameters.id, Location = "/estabelecimentos/v1/" + parameters.id, NomeFantasia = "Good Food Services" };
                    var usuarioResource = _userRepository.FindBy(id);

                    response = new JsonResponse(usuarioResource, new DefaultJsonSerializer()) { ContentType = "application/json", StatusCode = Nancy.HttpStatusCode.OK };

                }
                catch (Exception e)
                {
                    var error = new FriendlyErrorMessage("erro interno", "não foi possível completar a requisição");
                    response = new JsonResponse(error, new DefaultJsonSerializer()) { ContentType = "application/json", StatusCode = Nancy.HttpStatusCode.InternalServerError };
                    // throw; LOG!
                }

                return response;
            };

        }

    }
}
