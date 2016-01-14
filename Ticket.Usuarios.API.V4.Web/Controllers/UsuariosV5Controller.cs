using System.Web.Http;
using Ticket.API.Shared;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V5.Application.Commands;
using Ticket.Usuarios.API.V5.Application;
using Ticket.Usuarios.API.V5.Application.ResourceAssemblers;
using Ticket.Usuarios.API.V5.Representations;

namespace Ticket.Usuarios.API.V4.Web.Controllers
{
    public class UsuariosV5Controller : ApiController
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosV5Controller()
        {
            _usuarioService = new UsuarioService();

        }

     

        //exemplo de comando.
        //note que o ViewModel é um command, decorado com algumas regras de validação
        //este exemplo foi criado para mostrar como criar uma entidade complexa na camada de Serviço (UsuarioService)
        [HttpPost]
        public IHttpActionResult Novo(NovoUsuarioCompletoCommand novoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsuarioRepresentation usuarioCriado = null;

            try
            {
                usuarioCriado = _usuarioService.CriarNovoUsuarioComplexo(novoUsuario);
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

            return Ok(usuario);

        }
    }
}
