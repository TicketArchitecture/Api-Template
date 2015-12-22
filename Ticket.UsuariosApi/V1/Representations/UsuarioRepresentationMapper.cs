using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.Core.Representation;

namespace Ticket.UsuariosApi.V1.Representations
{
    public static class UsuarioRepresentationMapper
    {
        public static UsuarioRepresentation Map(Domain.Usuario usuario, ResourceLinker resourceLinker, NancyContext context)
        {
            return new UsuarioRepresentation(order)
            {
                Links = GetLinks(order, resourceLinker, context).ToList()
            };
        }

        private static IEnumerable<Link> GetLinks(Order order, Core.Representation.ResourceLinker linker, NancyContext context)
        {
            var get = new Link(
              linker.BuildUriString(context, "ReadOrder", new { orderId = order.Id }),
              context.Request.BaseUri() + "/docs/order-get.htm",
              MediaTypes.Default);

            var update = new Link(
              linker.BuildUriString(context, "UpdateOrder", new { orderId = order.Id }),
              context.Request.BaseUri() + "/docs/order-update.htm",
              MediaTypes.Default);

            var cancel = new Link(
              linker.BuildUriString(context, "CancelOrder", new { orderId = order.Id }),
              context.Request.BaseUri() + "/docs/order-cancel.htm",
              MediaTypes.Default);

            var pay = new Link(linker.BuildUriString(context, "PayOrder", new { orderId = order.Id }),
              context.Request.BaseUri() + "/docs/order-pay.htm",
              MediaTypes.Default);

            switch (order.Status)
            {
                case OrderStatus.Unpaid:
                    yield return get;
                    yield return update;
                    yield return cancel;
                    yield return pay;
                    break;
                case OrderStatus.Paid:
                case OrderStatus.Delivered:
                    yield return get;
                    break;
                case OrderStatus.Ready:
                    break;
                case OrderStatus.Canceled:
                    yield break;
                default:
                    yield break;
            }
        }
    }
}
