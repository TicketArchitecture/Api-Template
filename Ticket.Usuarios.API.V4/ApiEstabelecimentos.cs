using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Usuarios.API.V4
{
    public static class ApiEstabelecimentos
    {
        //TODO: mandar para AppSettings
        public static readonly string UrlApiEstabelecimentos = "https://api.ticket.com.br/estabelecimentos/v1/";
        public static string EstabelecimentosComComplemento(string segmento)
        {
            return String.Concat(UrlApiEstabelecimentos, segmento);
        }
    }
}
