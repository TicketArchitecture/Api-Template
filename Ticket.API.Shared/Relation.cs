using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.API.Shared
{
    public class Relation
    {
        private static string _relPrefix = "/rel/"; 
        public string Rel { get; set; }
        public string Uri { get; set; }
        public Relation(string rel,string uri)
        {
            rel = rel.StartsWith("/") == true ? rel.Remove(0) : rel;
            Rel = String.Concat(_relPrefix, rel);
            Uri = uri;
        }

    }
}
