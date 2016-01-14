using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.API.Shared.Infrastructure;
using Ticket.API.Shared.NH;
using Ticket.Usuarios.API.V5.Domain.ValueObjects;

namespace Ticket.Usuarios.API.V5.Domain
{
    public class Usuario : Entity
    {
        protected internal virtual int StatusValidacao { get; protected set; }
        protected internal virtual ICollection<EstabelecimentoFavorito> Favoritos { get;protected set;}
        protected internal virtual AparelhoTelefone Telefone { get; protected set; }
        protected internal virtual string Nome { get; protected set; }
        protected internal virtual string Email { get; protected set; }
        protected internal virtual bool AceitoMkt { get; protected set; }

        //NH
        internal Usuario(){}

        /// <summary>
        /// Exemplo de Entidade complexa para criar. É como se fosse um Aggregate Root (DDD). 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="email"></param>
        /// <param name="aceitoMkt"></param>
        /// <param name="telefone"></param>
        public Usuario(string nome, string email, bool aceitoMkt, AparelhoTelefone telefone)
        {
            Telefone = telefone;
            ICollection<string> erros = new List<string>();

            ValidarNome(nome, erros);
            ValidarEmail(email, erros);
            BusinessExceptionCreator.ThrowBusinessExceptionIfNeeded(erros);

            Nome = nome;
            Email = email;
            AceitoMkt = aceitoMkt;

        }

        public virtual void IncluirOuSubstituirAparelhoTelefone(string numero, string uuid, string sistemaOperacional)
        {
            Telefone = new AparelhoTelefone(numero, uuid, sistemaOperacional);
        }

        public virtual void IncluirEstabelecimentoEmMeusFavoritos(int id)
        {
            Favoritos.Add(new EstabelecimentoFavorito());
        }


        private void ValidarNome(string nome, ICollection<string> errors)
        {
            if (string.IsNullOrEmpty(nome) | nome.Length < 5)
            {
                errors.Add("UsuarioNome");
            }
        }
        private void ValidarEmail(string email, ICollection<string> errors)
        {
            if (string.IsNullOrEmpty(email) | !email.Contains("@"))
            {
                errors.Add("UsuarioEmail");
            }
        }
    }
}
