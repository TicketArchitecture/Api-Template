using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Usuarios.API.V4.Application.Commands
{
    public class NovoUsuarioCommand
    {
        public string Nome { get; private set; }
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
