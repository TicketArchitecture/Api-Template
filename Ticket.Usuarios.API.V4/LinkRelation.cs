using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Usuarios.API.V4
{
    public class LinkRelation
    {
        private static string _relPrefix = "/rels/";
        private static string _self = "self";
        public string Rel { get; set; }
        public string Uri { get; set; }

        /// <summary>
        /// A link with a Relation to another resource
        /// </summary>
        /// <param name="rel"></param>
        /// <param name="uri"></param>
        public LinkRelation(string rel, Uri uri)
        {
            rel = rel.StartsWith("/") == true ? rel.Remove(0) : rel;
            Rel = String.Concat(_relPrefix, rel);
            Uri = uri.ToString();
        }

        /// <summary>
        /// A Self link
        /// </summary>
        /// <param name="uri"></param>
        public LinkRelation(Uri uri)
        {
            Rel = _self;
            Uri = uri.ToString();
        }

        
    }
}
