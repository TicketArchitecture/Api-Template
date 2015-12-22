using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.UsuariosApi.Core.Domain;

namespace Ticket.UsuariosApi.V1.Domain.VOs
{
    public class FavoritoVO : ValueObject<FavoritoVO>
    {
        public virtual decimal  MinhaNota { get; private set; }
        public virtual decimal NotaGeral { get; private set; }
        public string IDEstabelecimento { get; private set; }
        public string NomeEstabelecimento{ get; private set; }

        public override bool SameValueAs(FavoritoVO other)
        {
            if (MinhaNota != other.MinhaNota)
                return false;
            if (NotaGeral != other.NotaGeral)
                return false;
            if (!IDEstabelecimento.Equals(other.IDEstabelecimento))
                return false;
            if (!NomeEstabelecimento.Equals(other.NomeEstabelecimento))
                return false;

            return true;
        }
    }
}
