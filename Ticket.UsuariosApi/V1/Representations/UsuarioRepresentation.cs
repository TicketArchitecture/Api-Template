using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.Core;
using Ticket.UsuariosApi.Core.Data.NH.Entities;

namespace Ticket.UsuariosApi.V1.Representations
{
    public class UsuarioRepresentation : Entity
    {
        public UsuarioRepresentation()
        {

        }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime Nascimento { get; set; }
        public virtual string Senha { get; set; }
        public virtual string UuidTelefone { get; set; }
    }
}
