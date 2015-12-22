using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.UsuariosApi.V4.Representations
{
    public class LinkRelation
    {
        private static string _relPrefix = "/rel/";
        public string Rel { get; set; }
        public string Uri { get; set; }
        public LinkRelation(string rel, string uri)
        {
            rel = rel.StartsWith("/") == true ? rel.Remove(0) : rel;
            Rel = String.Concat(_relPrefix, rel);
            Uri = uri;
        }
    }
}
