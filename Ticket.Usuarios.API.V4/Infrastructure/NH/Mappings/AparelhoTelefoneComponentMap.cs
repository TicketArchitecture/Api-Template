using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Ticket.Usuarios.API.V4.Domain;

namespace Ticket.Usuarios.API.V4.Infrastructure.NH.Mappings
{
    public class AparelhoTelefoneComponentMap : ComponentMap<AparelhoTelefone>
    {
        public AparelhoTelefoneComponentMap()
        {
            Map(x => x.Numero, "numero_telefone");
            Map(x => x.SistemaOperacional, "sistema_operacional_telefone");
            Map(x => x.UUID, "uuid_telefone");
            Map(x => x.Validado, "telefone_validado");
        }
    }
}
