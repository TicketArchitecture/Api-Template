using Ticket.Mobile.Domain.Entities;

namespace Ticket.UsuariosApi.Infrastructure.Mappings
{
    public class CartaoMap : MapBase<Cartao>
    {
        public CartaoMap()
        {
            Table("Cartao");
            Id(x => x.Id, m => m.Column("CdCartao"));
            Property(x => x.Apelido, m => m.Column("NmApelido"));
            Property(x => x.NumeroCriptografado, m => m.Column("NumCartao"));

            ManyToOne(x => x.Usuario, m => m.Column("CdUsuario"));
        }
    }
}