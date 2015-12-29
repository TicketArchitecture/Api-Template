using System;
using System.Collections;
using System.Collections.Generic;

namespace Ticket.API.Shared.Infrastructure
{
    public class BusinessException : Exception
    {
        private IDictionary<string, string> _errors = new Dictionary<string, string>();
        public BusinessException(IDictionary<string,string> errors)
        {
            _errors= errors;

        }

        public BusinessException(string nomeResource, string mensagem) : base(mensagem)
        {

            _errors.Add(nomeResource, mensagem);

        }

       
        public override IDictionary Data
        {
            get
            {
                return _errors as IDictionary;
            }
        }

    }
}
