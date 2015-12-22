using System;
using System.Web.Http;
using Ticket.API.Shared.Attributes;
using Ticket.API.Shared.Controllers;
using Ticket.Usuarios.API.Shared;
using Ticket.Usuarios.API.V4.Application.ResourceAssemblers;
using Ticket.Usuarios.API.V4.Representations;

namespace Ticket.Usuarios.API.V4.Web.Controllers
{
    
    public class UsuariosController : APIBaseController
    {
        //Exemplo de Query
        public IHttpActionResult GetById(int id)
        {
            var usuario = Database.Session.Get<UsuarioRepresentation>(id);

            return GerarResponse(usuario);
        }

        //Exemplo de Query
        [HttpGet]
        [APITransactionalActionBase]
        public IHttpActionResult Search(string nome)
        {
            var usuario = Database.Session.QueryOver<UsuarioRepresentation>()
                .WhereRestrictionOn(m => m.Nome).IsInsensitiveLike(nome)
                .SingleOrDefault();

            return GerarResponse(usuario);
        }

        private IHttpActionResult GerarResponse(UsuarioRepresentation usuario)
        {
            if (usuario == null)
                return NotFound();

            UsuarioResourceAssembler.AddRelationLinks(usuario, Request.RequestUri);

            return Json<UsuarioRepresentation>(usuario);

        }
    }
}
