using Ticket.Mobile.Domain.Entities;

namespace Ticket.UsuariosApi.Infrastructure.Mappings
{
    public class TokenMap : MapBase<Token>
    {
        public TokenMap()
        {
            Table("UsuarioFacebook");
            Id(x => x.Id, m => m.Column("CdUsuarioFacebook"));

            Property(x => x.Codigo, m => m.Column("CdTokenFacebook"));

            ManyToOne(x => x.Usuario, m => m.Column("CdUsuario"));
        }
    }
}