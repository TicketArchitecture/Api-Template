using Ticket.UsuariosApi.Core.Domain;

namespace Ticket.UsuariosApi.Core.Data.NH.Entities
{
    public abstract class ValueObject<T> : BusinessValidator
    {
        public virtual int Id { get; set; }
        public abstract bool SameValueAs(T other);
    }
}
