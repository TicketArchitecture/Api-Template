using System.Collections.Generic;
using Ticket.API.Shared.Infrastructure;
using Ticket.API.Shared.NH;

namespace Ticket.Usuarios.API.V4.Domain
{
    /// <summary>
    /// Este Usuário representa unicamente aquele gerado durante a criação 
    /// de um usuário novo no sistema. Note que os atributos de classe se resumem
    /// aos necessários para este momento do ciclo de vida de um Usuário.
    /// </summary>
    public class UsuarioDadosMinimos : Entity
    {
        protected internal virtual string Nome {  get; protected set; }
        protected internal virtual string Email { get; protected set; }
        protected internal virtual bool AceitoMkt { get; protected set; }

        public UsuarioDadosMinimos(string nome, string email, bool aceitoMkt)
        {
            ICollection<string> erros = new  List<string>();

            ValidarNome(nome, erros);
            ValidarEmail(email, erros);
            BusinessExceptionCreator.ThrowBusinessExceptionIfNeeded(erros);

            Nome = nome;
            Email = email;
            AceitoMkt = aceitoMkt;
            

        }

        internal UsuarioDadosMinimos(){}


        private void ValidarNome(string nome, ICollection<string> errors)
        {
            if(string.IsNullOrEmpty(nome)|nome.Length < 5)
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
