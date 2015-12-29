using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.API.Shared.NH;
using Ticket.Usuarios.API.V4.Domain.ValueObjects;

namespace Ticket.Usuarios.API.V4.Domain
{
    public class Usuario: UsuarioDadosMinimos
    {
        protected internal virtual int StatusValidacao { get; protected set; }
        protected internal virtual ICollection<EstabelecimentoFavorito> Favoritos { get;protected set;}
        protected internal virtual AparelhoTelefone Telefone { get; protected set; }

        //NH
        internal Usuario(){}

        public virtual void IncluirOuSubstituirAparelhoTelefone(string numero, string uuid, string sistemaOperacional)
        {
            Telefone = new AparelhoTelefone(numero, uuid, sistemaOperacional);
        }

        public virtual void IncluirEstabelecimentoEmMeusFavoritos(int id)
        {
            Favoritos.Add(new EstabelecimentoFavorito());
        }
    }
}
