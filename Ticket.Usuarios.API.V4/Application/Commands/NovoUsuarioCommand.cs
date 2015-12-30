using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ticket.Usuarios.API.V4.Application.Commands
{
    public class NovoUsuarioCommand
    {
        [MinLength(5,ErrorMessageResourceName ="Usuario.Nome")]
        public string Nome { get; private set; }

        [DataType(DataType.EmailAddress)]
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
