using System.Web.Http;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V4.Application.Commands;
using Ticket.Usuarios.API.V4.Application.Contracts;
using Ticket.Usuarios.API.V4.Application.ResourceAssemblers;
using Ticket.Usuarios.API.V4.Representations;

namespace Ticket.Usuarios.API.V4.Web.Controllers
{
    public class UsuariosController : ApiController
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

            UsuarioRepresentation usuarioCriado = null;

            try
            {
                usuarioCriado = _usuarioService.CriarNovoUsuario(novoUsuario);
            }
            catch (BusinessException be)
            {
                ExceptionConversor.ComplementModelStateErrors(ModelState, be);
                return BadRequest(ModelState);
            }
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
