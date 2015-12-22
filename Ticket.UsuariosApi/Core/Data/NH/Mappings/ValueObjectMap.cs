
using FluentNHibernate.Mapping;

using Ticket.UsuariosApi.Core.Data.NH.Entities;

namespace Ticket.UsuariosApi.Core.Data.NH.Mappings
{
    public class ValueObjectMap<T> : ClassMap<T>
        where T : ValueObject<T>
    {
        protected ValueObjectMap(string keyColumn)
        {
            Id(x => x.Id, keyColumn);

            OptimisticLock.Version();
        }
    }
}
