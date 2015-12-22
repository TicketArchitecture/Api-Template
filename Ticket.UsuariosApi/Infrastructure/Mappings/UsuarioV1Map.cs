using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.Core.Data.NH.Mappings;

namespace Ticket.UsuariosApi.Infrastructure.Mappings
{
    public class UsuarioV1Map: EntityMap<V1.Domain.Usuario>
    {
        public UsuarioV1Map():base("CdUsuario")
        {
            Table("Usuario");
            Map(x => x.Nome)
                .Column("NmUsuario");
            
            Map(x => x.CPF)
                .Column("NumCpf");

            //Component(x => x.Contato, m =>
            //{
            //    m.Map(x=>x.);

            //});
            //Property(x => x.Email, m => m.Column("Email"));
            //Property(x => x.Senha, m => m.Column("Senha"));
        }

    }
}
