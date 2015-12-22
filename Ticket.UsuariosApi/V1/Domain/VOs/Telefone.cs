using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.Core.Domain;

namespace Ticket.UsuariosApi.V1.Domain.VOs
{
    public class Telefone : ValueObject<Telefone>
    {
        public virtual int DDD { get; set; }
        public virtual string Numero { get; set; }
        public virtual string UUID { get; set; }

        public Telefone(int ddd, string numero, string id)
        {
            var erros = new Dictionary<string, string>();
            if (!dddValido(ddd))
                erros.Add("ddd", "inválido");

            if (!numeroValido(numero))
                erros.Add("telefone", "número inválido");

            if (String.IsNullOrEmpty(id))
                erros.Add("Id", "inválido");

            base.Validate(erros);


        }

        private bool numeroValido(string numero)
        {
            //mais validações devem ser feitas
            if (numero.Length == 8 | numero.Length == 9)
                return true;
            return false;
        }

        private bool dddValido(int ddd)
        {
            if (ddd > 10 & ddd < 100)
                return true;
            return false;
        }

        public override bool SameValueAs(Telefone other)
        {
            throw new NotImplementedException();
        }
    }
}
