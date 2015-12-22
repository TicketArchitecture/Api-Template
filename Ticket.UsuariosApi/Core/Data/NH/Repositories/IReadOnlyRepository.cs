using System;
using System.Linq;
using System.Linq.Expressions;

using Ticket.UsuariosApi.Core.Data.NH.Entities;

namespace Ticket.UsuariosApi.Core.Data.NH.Repositories
{
    public interface IReadOnlyRepository<T> where T : Entity
    {
        T FindBy(object id);

        IQueryable<T> All();

        T FindBy(Expression<Func<T, bool>> expression);

        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}