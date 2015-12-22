using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Usuarios.API.V4
{
    public static class Version
    {
        public static readonly string Current = "V4";
        public static readonly string UsuariosPartialUrl = "usuarios/v4/";
        
        //TODO: colocar o baseAddress no appSettings
        public static readonly string BaseAddress = "https://api.ticket.com.br/Ticket.Mobile.Dese/";

        public static readonly string FullAPIEndpoint = string.Concat(BaseAddress, UsuariosPartialUrl);

        public static string UsuariosComComplemento(string segmento)
        {
            return String.Concat(FullAPIEndpoint, segmento);
        }
    }
}
