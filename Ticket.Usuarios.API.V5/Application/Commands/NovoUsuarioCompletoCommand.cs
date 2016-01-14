using System.ComponentModel.DataAnnotations;
using Ticket.API.Shared;

namespace Ticket.Usuarios.API.V5.Application.Commands
{
    public class NovoUsuarioCompletoCommand: NovoUsuarioCommand
    {
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "TelefoneNumero",
            ErrorMessageResourceType = typeof(BusinessErrorsResource))]
        public string Numero { get; private set; }

        [MinLength(10, ErrorMessageResourceName = "TelefoneUUID", 
            ErrorMessageResourceType =typeof(BusinessErrorsResource))]
        public string UUID { get; private set; }
        public bool Validado { get; private set; }

        [MinLength(10, ErrorMessageResourceName = "TelefoneSistemaOperacional",
            ErrorMessageResourceType = typeof(BusinessErrorsResource))]
        public virtual string SistemaOperacional { get; private set; }

        //não reforce regras de negócio aqui. Deixe-as para as entidades.
        public NovoUsuarioCompletoCommand(string numero, string uuid, bool validado, string so,string nome, string email, bool aceitoMkt):base(nome,email,aceitoMkt)
        {
            Numero = numero;
            UUID = uuid;
            Validado = validado;
            SistemaOperacional = so;
        }

    }
}
