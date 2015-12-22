using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.V4.Representations;

namespace Ticket.UsuariosApi.V4.Transitions
{
    public static class UsuarioAssembler
    {
        public static UsuarioRepresentation AssemblyWithLinks(string requestUri, UsuarioRepresentation usuario)
        {
            return AssemblyWithLinks(new Uri(requestUri), usuario);
        }

        public static UsuarioRepresentation AssemblyWithLinks(Uri requestUri, UsuarioRepresentation usuario)
        {

            return GetLinks(requestUri, usuario);

        }

        private static UsuarioRepresentation GetLinks(Uri requestUri, UsuarioRepresentation usuario)
        {
            throw new NotImplementedException();
        }
    }
}
