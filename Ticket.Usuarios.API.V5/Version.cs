using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Usuarios.API.V5
{
    public static class Version
    {
        public static readonly string Current = "V5";
        public static readonly string UsuariosPartialUrl = "usuarios/v5/";

 #if DEBUG
        //TODO: obter dinamicamente
        public static string BaseAddress = "http://localhost:58779/";

#else
        //TODO: colocar o baseAddress no appSettings
        public static string BaseAddress = "https://api.ticket.com.br/Ticket.Mobile.Dese/";

#endif
        public static readonly string FullAPIEndpoint = string.Concat(BaseAddress, UsuariosPartialUrl);

        public static string UsuariosComComplemento(string segmento)
        {
            return String.Concat(FullAPIEndpoint, segmento);
        }
    }
}
