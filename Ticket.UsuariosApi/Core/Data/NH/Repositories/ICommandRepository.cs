using System.Collections.Generic;

using Ticket.UsuariosApi.Core.Data.NH.Entities;

namespace Ticket.UsuariosApi.Core.Data.NH.Repositories
{
    public interface ICommandRepository<T>  where T : Entity
    {
        void Add(T entity);

        void Add(IEnumerable<T> items);

        void Update(T entity);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);
    }
}
