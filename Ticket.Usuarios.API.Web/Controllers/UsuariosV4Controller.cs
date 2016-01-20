using System.Web.Http;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V4.Application.Commands;
using Ticket.Usuarios.API.V4.Application;
using Ticket.Usuarios.API.V4.Application.ResourceAssemblers;
using Ticket.Usuarios.API.V4.Representations;
using log4net;
using System.Collections.Generic;

namespace Ticket.Usuarios.API.Web.Controllers
{
    public class UsuariosV4Controller : ApiController
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(UsuariosV4Controller).FullName);

        private readonly UsuarioService _usuarioService;

        public UsuariosV4Controller()
        {
            _usuarioService = new UsuarioService();

        }

        //Exemplo de Query
        public IHttpActionResult GetById(int id)
        {
            var usuario = Database.Session.Get<UsuarioRepresentation>(id);
            throw new System.Exception("Erro intencional");
            return GerarResponse(usuario);
        }

        //Exemplo de Query
        [HttpGet]
        public IHttpActionResult Search(string nome)
        {
            var usuarios = Database.Session.QueryOver<UsuarioRepresentation>()
                .WhereRestrictionOn(m => m.Nome).IsInsensitiveLike(nome, NHibernate.Criterion.MatchMode.Anywhere)
                .List<UsuarioRepresentation>();

            return GerarResponse(usuarios);
        }

        //exemplo de comando.
        //note que o ViewModel é um command, decorado com algumas regras de validação
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
            if (_log.IsDebugEnabled)
                _log.Debug(Request.RequestUri.ToString());

            if (usuario == null)
                return NotFound();

            UsuarioResourceAssembler.AddRelationLinks(usuario, Request.RequestUri);

            return Ok(usuario);

        }

        private IHttpActionResult GerarResponse(IList<UsuarioRepresentation> usuarios)
        {
            if (usuarios.Count == 0)
                return NotFound();

            foreach(var usuario in usuarios)
                UsuarioResourceAssembler.AddRelationLinks(usuario, Request.RequestUri);

            return Ok(usuarios);

        }
    }
}
