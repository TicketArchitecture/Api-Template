using Ticket.Mobile.Domain.Entities;

namespace Ticket.UsuariosApi.Infrastructure.Mappings
{
    public class AvaliacaoMap : MapBase<Avaliacao>
    {
        public AvaliacaoMap()
        {
            Table("EstabelecimentoAvaliacao");
            Id(x => x.Id, m => m.Column("CdEstabelecimentoAvaliacao"));

            Property(x => x.Critica, m => m.Column("DsAvaliacao"));
            Property(x => x.Nota, m => m.Column("QtPontuacao"));

            ManyToOne(x => x.Estabelecimento, m => m.Column("CdEstabelecimento"));
            ManyToOne(x => x.Usuario, m => m.Column("CdUsuario"));
        }
    }
}