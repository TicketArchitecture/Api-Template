using System;
using System.Web.Http;
using Ticket.API.Shared.Attributes;
using Ticket.API.Shared.Controllers;
using Ticket.API.Shared;
using Ticket.Usuarios.API.V4.Application.ResourceAssemblers;
using Ticket.Usuarios.API.V4.Representations;
using Ticket.Usuarios.API.V4.Application.Commands;
using Ticket.Usuarios.API.V4.Application.Contracts;

namespace Ticket.Usuarios.API.V4.Web.Controllers
{
    //note que o APIBaseController utiliza um filtro global 
    //que gerencia a transação automaticamente
    public class UsuariosController : APIBaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }

        //Exemplo de Query
        public IHttpActionResult GetById(int id)
        {
            var usuario = Database.Session.Get<UsuarioRepresentation>(id);

            return GerarResponse(usuario);
        }

        //Exemplo de Query
        [HttpGet]
        //utilizando contexto transacional local
        [APITransactionalActionBase]
        public IHttpActionResult Search(string nome)
        {
            var usuario = Database.Session.QueryOver<UsuarioRepresentation>()
                .WhereRestrictionOn(m => m.Nome).IsInsensitiveLike(nome)
                .SingleOrDefault();

            return GerarResponse(usuario);
        }

        //exemplo de comando.
        //note que o Model é um command, decorado com algumas regras de validação
        [HttpPost]
        public IHttpActionResult Novo(NovoUsuarioCommand novoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioCriado = _usuarioService.CriarNovoUsuario(novoUsuario);
            return GerarResponse(usuarioCriado);
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
