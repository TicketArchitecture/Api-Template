using System.Web.Mvc;
using Ticket.API.Shared.Attributes;

namespace Ticket.API.Shared.Controllers
{
    [MVCUseTransactionsByDefault]
    public class MVCBaseController : Controller
    {
    }
}
