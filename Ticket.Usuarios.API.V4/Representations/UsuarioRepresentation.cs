using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Usuarios.API.V4.Domain;

namespace Ticket.Usuarios.API.V4.Representations
{
    public class UsuarioRepresentation : IResource
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual bool AceitoMkt { get; set; }
        public virtual int StatusValidacao { get; set; }

        public virtual List<LinkRelation> Links { get; set; }
        public virtual AparelhoTelefone Telefone { get; set; }
            
    }
}
