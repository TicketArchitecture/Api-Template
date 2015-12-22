using FluentNHibernate.Mapping;
using Ticket.UsuariosApi.Core.Data.NH.Mappings;
using Ticket.UsuariosApi.V1.Representations;

namespace Ticket.UsuariosApi.Infrastructure.Mappings.Resources
{
    public class UsuarioResourceV1Map : EntityMap<UsuarioRepresentation>
    {
        public UsuarioResourceV1Map():base("CdUsuario")
        {
            Table("Usuario");
            Map(x => x.Nome)
                .Column("NmUsuario");
            Map(x => x.Email)
                .Column("Email")
                .Not.Nullable();
            Map(x => x.Cpf)
                .Column("NumCpf")
                .Nullable();
            Map(x => x.Telefone)
                .Column("NumCelular");
            Map(x => x.UuidTelefone)
                .Column("NumDevice");
        }
    }
}