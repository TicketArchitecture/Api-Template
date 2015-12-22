using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Ticket.Usuarios.API.V4.Domain;

namespace Ticket.Usuarios.API.V4.Infrastructure.NH.Mappings
{
    public class UsuarioMap: SubclassMap<Usuario>
    {
        public UsuarioMap()
        {
            Map(x => x.StatusValidacao, "status_validacao");
            Component(x => x.Telefone);

        }
    }
}
