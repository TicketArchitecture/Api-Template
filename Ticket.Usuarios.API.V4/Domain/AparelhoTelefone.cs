using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.Usuarios.API.V4.Domain
{
    public class AparelhoTelefone
    {
        public virtual string Numero { get; private set; }
        public virtual string UUID { get; private set; }
        public virtual string SistemaOperacional { get; private set; }
        public virtual bool Validado { get; private set; }

        public AparelhoTelefone(string numero, string uuid, string sistemaOperacional)
        {
            if (!NumeroValido(numero))
                BusinessValidator.ThrowBusinessExceptionWithResourcesMessage("AparelhoTelefone.Numero");

            Numero = numero;
            UUID = uuid;
            SistemaOperacional = sistemaOperacional;
        }

        private bool NumeroValido(string numero)
        {
            long numeroAnalisado = 0;

            if (String.IsNullOrEmpty(numero) || !Int64.TryParse(numero, out numeroAnalisado))
                return false;

            return true;
               
        }

        //formalidade NH
        internal AparelhoTelefone() { }

        public void MarcarComoValidado() {
            Validado = true;
        }
    }
}
