using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.API.Shared.NH
{
    //de FluentNHibernate:
    //The default behavior is to consider abstract classes 
    //as layer supertypes* and effectively unmapped.
    //*http://martinfowler.com/eaaCatalog/layerSupertype.html
    public abstract class Entity
    {
        
        public virtual int Id { get; private set; }
    }
}
