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
        public virtual int StatusValidacao { get; private set; }
        public virtual ICollection<EstabelecimentoFavorito> Favoritos { get;private set;}
        public virtual AparelhoTelefone Telefone { get; private set; }

        //NH
        internal Usuario(){}

        public void IncluirOuSubstituirAparelhoTelefone(string numero, string uuid, string sistemaOperacional)
        {
            Telefone = new AparelhoTelefone(numero, uuid, sistemaOperacional);
        }

        public void IncluirEstabelecimentoEmMeusFavoritos(int id)
        {
            Favoritos.Add(new EstabelecimentoFavorito());
        }
    }
}
