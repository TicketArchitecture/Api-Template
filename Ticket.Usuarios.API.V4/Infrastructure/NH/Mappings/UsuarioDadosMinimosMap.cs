using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Ticket.Usuarios.API.V4.Domain;

namespace Ticket.Usuarios.API.V4.Infrastructure.NH.Mappings
{
    public class UsuarioDadosMinimosMap : ClassMapping<UsuarioDadosMinimos>
    {
        public UsuarioDadosMinimosMap()
        {
            Table("Usuarios");
            Id(x => x.Id, x =>
            {
                x.Column("id");
                x.Generator(Generators.Native);
                }
            
            );
            Property(x => x.Nome, x =>
            {
                x.Column("nome_completo");
                x.NotNullable(true);
            });
            Property(x => x.Email, x =>
            {
                x.Column("email");
                x.NotNullable(true);
            });
            Property(x => x.AceitoMkt, x =>
            {
                x.Column("aceita_mkt");
                x.NotNullable(true);
            });

        }

    }
}
