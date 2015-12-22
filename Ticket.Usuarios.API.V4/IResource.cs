using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Usuarios.API.V4
{
    public interface IResource
    {
        List<LinkRelation> Links { get; set; }

    }
}
