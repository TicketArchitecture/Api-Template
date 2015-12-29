﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.Usuarios.API.V4.Domain
{
    public class NovoEstabelecimentoFavorito
    {
        public virtual int Id { get; private set; }
        public virtual int MinhaNota { get; private set; }

        public NovoEstabelecimentoFavorito(int id,int notaAtribuida)
        {
            ICollection<string> erros = new List<string>();

            if (!IdValido(id))
                erros.Add("NovoEstabelecimentoFavorito.Id");

            ValidarNotaAtribuida(notaAtribuida, erros);
            BusinessValidator.ThrowBusinessExceptionIfNeeded(erros);

        }

        public NovoEstabelecimentoFavorito(int id)
        {

            if (!IdValido(id))
                BusinessValidator.ThrowBusinessExceptionWithResourcesMessage("NovoEstabelecimentoFavorito.Id");
        }

        
        private void ValidarNotaAtribuida(int notaAtribuida, ICollection<string> erros)
        {
            if (notaAtribuida < 0 || notaAtribuida > 5)
                erros.Add("NovoEstabelecimentoFavorito.NotaAtribuida");
        }

        private bool IdValido(int id)
        {
            if (id < 1)
                return false;
            return true;
        }
    }
}
