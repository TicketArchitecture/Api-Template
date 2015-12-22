using System.Collections.Generic;

using NHibernate;

using Ticket.UsuariosApi.Core.Data.NH.Entities;
using Ticket.UsuariosApi.Core.Data.NH.Repositories;

namespace Ticket.UsuariosApi.Core.Data
{
    public class CommandRepository<T> : ICommandRepository<T>
        where T : Entity
    {
        protected readonly ISession _session;

        public CommandRepository(ISession session)
        {
            _session = session;
        }

        public virtual void Add(T entity)
        {
            _session.Save(entity);
        }

        public virtual void Add(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                _session.Save(item);
            }
        }

        public virtual void Update(T entity)
        {
            _session.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _session.Delete(entity);
            }
        }
    }
}
