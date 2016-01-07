using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using Ticket.Usuarios.API.V4.Domain;
using Ticket.Usuarios.API.V4.Representations;

namespace Ticket.Usuarios.API.V4.Infrastructure.NH.Mappings
{
    public class UsuarioRepresentationMapping : ClassMapping<UsuarioRepresentation>
    {
        public UsuarioRepresentationMapping()
        {
            Table("Usuarios");
            Id(x => x.Id, x => x.Column("id"));
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
            Property(x => x.StatusValidacao, x =>
            {
                x.Column("status_validacao");
                x.NotNullable(true);
            });

            Component<AparelhoTelefoneRepresentation>(x => x.Telefone, x =>
            {
                x.Property(y => y.Numero, y => y.Column("numero_telefone"));
                x.Property(y => y.SistemaOperacional, y => y.Column("sistema_operacional_telefone"));
                x.Property(y => y.Validado, y => y.Column("telefone_validado"));
                x.Property(y => y.UUID, y => y.Column("uuid_telefone"));


            });
        }
    }
}
