using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Ticket.Usuarios.API.V4.Domain;

namespace Ticket.Usuarios.API.V4.Infrastructure.NH.Mappings
{
    public class UsuarioDadosMinimosMap : ClassMap<UsuarioDadosMinimos>
    {
        public UsuarioDadosMinimosMap()
        {
            Table("Usuarios");
            Id(x => x.Id, "id");
            Map(x => x.Nome, "nome_completo");
            Map(x => x.Email, "email");
            Map(x => x.AceitoMkt, "aceita_mkt");
                
        }

    }
}
