using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.Core.Data.NH.Entities;
using Ticket.UsuariosApi.Core.Domain;
using Ticket.UsuariosApi.V1.Domain.VOs;

namespace Ticket.UsuariosApi.V1.Domain
{
    public class Usuario : Entity
    {
        public virtual string Nome { get;}
        public virtual Contato Contato { get; }
        public virtual string CPF { get; }
        public virtual DateTime Nascimento { get; set; }

        //NH crap
        protected Usuario() { }

        public Usuario(string nome,Contato contato, string cpf = "")
        {
            var erros = new Dictionary<string, string>();
            if (nome.Length < 10)
                erros.Add("nome", "Deve conter pelo menos 10 caracteres");

            var cpfErrorMessage = String.Empty;

            if (!String.IsNullOrEmpty(cpf) && !cpfValido(cpf, out cpfErrorMessage))
                erros.Add("cpf", cpfErrorMessage);
            //try
            //{
            //    Contato = new Contato(contato.)

            //}


        }

        private bool cpfValido(string cpf,out string errorMessage)
        {
            
           //validar o suficiente para atender ao negócio
            errorMessage = string.Empty;
            return true;

        }
    }
}
