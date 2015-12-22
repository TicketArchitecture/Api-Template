using System;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Linq;

using Ticket.UsuariosApi.Core.Data.NH.Entities;
using Ticket.UsuariosApi.Core.Data.NH.Repositories;

namespace Ticket.UsuariosApi.Core.Data
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T>
        where T : Entity
    {
        private readonly ISession _session;

        public ReadOnlyRepository(ISession session)
        {
            _session = session;
        }

        public T FindBy(object id)
        {
            return _session.Get<T>(id);
        }

        public T FindBy<TKey>(TKey id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).FirstOrDefault();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }
    }
}
