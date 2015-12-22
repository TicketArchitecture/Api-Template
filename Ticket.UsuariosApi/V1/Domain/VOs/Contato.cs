using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.Core.Domain;

namespace Ticket.UsuariosApi.V1.Domain.VOs
{
    public class Contato : ValueObject<Contato>
    {
        public virtual Telefone Telefone { get; set; }
        public virtual string Email { get; set; }

        public Contato(int ddd,int telefone,string email,string idTelefone)
        {
            var erros = new Dictionary<string, string>();
            if (!EmailIsValid(email))
                erros.Add("Email de Contato", "inválido");

            
        }

        private bool EmailIsValid(string email)
        {
            throw new NotImplementedException();
        }

        public override bool SameValueAs(Contato other)
        {
            throw new NotImplementedException();
        }
    }
}
