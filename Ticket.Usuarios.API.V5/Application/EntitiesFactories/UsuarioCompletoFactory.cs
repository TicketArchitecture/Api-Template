using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Usuarios.API.V5.Domain;

namespace Ticket.Usuarios.API.V5.Application.EntitiesFactories
{
    /// <summary>
    /// Esta classe é o único ponto da aplicação que sabe como contruir este objeto mais complexo além do NHibernate.
    /// Pode parecer que estamos colocando regras de negócio aqui, mas na verdade elas estão
    /// somente nas próprias entidades envolvidas.
    /// http://stackoverflow.com/a/32698882/1456567
    /// </summary>
    internal class UsuarioCompletoFactory
    {
        public static Usuario Create(Commands.NovoUsuarioCompletoCommand cmd)
        {
            var telefone = new AparelhoTelefone(cmd.Numero, cmd.UUID, cmd.SistemaOperacional);
            var usuarioCompleto = new Usuario(cmd.Nome, cmd.Email, cmd.AceitoMkt, telefone);

            return usuarioCompleto;
        }
    }
}
