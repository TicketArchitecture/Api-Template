using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Ticket.API.Shared.Attributes;

namespace Ticket.API.Shared.Controllers
{
    [APIUseTransactionsByDefault]
    public class APIBaseController : ApiController
    {
    }
}
