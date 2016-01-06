using System.ComponentModel.DataAnnotations;
using Ticket.API.Shared;

namespace Ticket.Usuarios.API.V4.Application.Commands
{
    public class NovoUsuarioCommand
    {
        [MinLength(5, ErrorMessageResourceName = "UsuarioNome",
            ErrorMessageResourceType = typeof(BusinessErrorsResource))]
        public string Nome { get; private set; }

        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "UsuarioEmail", 
            ErrorMessageResourceType =typeof(BusinessErrorsResource))]
        public string Email { get; private set; }
        public bool AceitoMkt { get; private set; }

        //não reforce regras de negócio aqui. Deixe-as para as entidades.
        public NovoUsuarioCommand(string nome, string email, bool aceitoMkt)
        {
            Nome = nome;
            Email = email;
            AceitoMkt = aceitoMkt;
        }

    }
}
