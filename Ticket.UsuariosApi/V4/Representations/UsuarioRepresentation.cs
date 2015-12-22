using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.UsuariosApi.V4.Representations
{
    public class UsuarioRepresentation
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool AceitoMkt { get; set; }
        public int StatusValidacao { get; set; }

        public int MyProperty { get; set; }

    }
}
