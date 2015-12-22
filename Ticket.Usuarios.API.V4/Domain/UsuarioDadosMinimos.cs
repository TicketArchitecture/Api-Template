using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Ticket.API.Shared.Infrasctructure;
using Ticket.API.Shared.NH;
using Ticket.Usuarios.API.V4.Domain.ValueObjects;

namespace Ticket.Usuarios.API.V4.Domain
{
    /// <summary>
    /// Este Usuário representa unicamente aquele gerado durante a criação 
    /// de um usuário novo no sistema. Note que os atributos de classe se resumem
    /// aos necessários para este momento do ciclo de vida de um Usuário.
    /// </summary>
    public class UsuarioDadosMinimos : Entity
    {
        internal virtual string Nome { get; private set; }
        internal virtual string Email { get; private set; }
        internal virtual bool AceitoMkt { get; private set; }

        public UsuarioDadosMinimos(string nome, string email, bool aceitoMkt)
        {
            ICollection<string> erros = new  List<string>();

            ValidarNome(nome, erros);
            ValidarEmail(email, erros);
            BusinessValidator.ThrowBusinessExceptionIfNeeded(erros);

            Nome = nome;
            Email = email;
            AceitoMkt = aceitoMkt;
            

        }

        internal UsuarioDadosMinimos(){}


        private void ValidarNome(string nome, ICollection<string> errors)
        {
            if(string.IsNullOrEmpty(nome)|nome.Length < 10)
            {
                errors.Add("Usuario.Nome");
            }
        }
        private void ValidarEmail(string email, ICollection<string> errors)
        {
            if (string.IsNullOrEmpty(email) | !email.Contains("@"))
            {
                errors.Add("Usuario.Email");
            }
        }
    }
}
