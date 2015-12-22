using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.API.Shared
{
    public class Representation
    {
        public IList<Relation> Links { get; set; }
        public Representation()
        {

        }
    }
}
