
using FluentNHibernate.Mapping;

using Ticket.UsuariosApi.Core.Data.NH.Entities;

namespace Ticket.UsuariosApi.Core.Data.NH.Mappings
{
    public class EntityMap<T> : ClassMap<T>
        where T : Entity
    {
        protected EntityMap(string keyColumn)
        {
            Id(x => x.Id, keyColumn);


            Map(x => x.DataCriacao)
                .Column("DthrCriacao")
                .Not.Nullable()
                .Not.Update();

            Map(x => x.DataAlteracao)
                .Column("DthrAlteracao")
                .Nullable()
                .Not.Insert();

            // Version(x => x.Versao).Column("nu_versao");

            //OptimisticLock.Version();
        }
    }
}
