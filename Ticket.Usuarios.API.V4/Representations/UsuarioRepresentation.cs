using System.Collections.Generic;

namespace Ticket.Usuarios.API.V4.Representations
{
    public class UsuarioRepresentation
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual bool AceitoMkt { get; set; }
        public virtual int StatusValidacao { get; set; }
        public virtual List<LinkRelation> Links { get; set; }
        public virtual AparelhoTelefoneRepresentation Telefone { get; set; }
            
    }

    public class AparelhoTelefoneRepresentation
    {

        public virtual string Numero { get; private set; }
        public virtual string UUID { get; private set; }
        public virtual string SistemaOperacional { get; private set; }
        public virtual bool Validado { get; private set; }
    }
}
