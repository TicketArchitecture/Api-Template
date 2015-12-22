using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Usuarios.API.V4.Domain.ValueObjects
{
    public class EstabelecimentoFavorito
    {
        public virtual int IdEstabelecimento { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal AvaliacaoMedia { get; set; }
        public virtual int MinhaAvaliacao { get; set; }
        public virtual float Latitude { get; set; }
        public virtual float Longitute { get; set; }
    }
}
