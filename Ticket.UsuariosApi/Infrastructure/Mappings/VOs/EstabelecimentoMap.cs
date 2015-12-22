using NHibernate.Mapping.ByCode;
using Ticket.Mobile.Domain.Entities;

namespace Ticket.UsuariosApi.Infrastructure.Mappings
{
    public class EstabelecimentoMap : MapBase<Estabelecimento>
    {
        public EstabelecimentoMap()
        {
            Table("Estabelecimento");
            Id(x => x.Id, m => m.Column("CdEstabelecimento"));

            Property(x => x.Codigo, m => m.Column("CdEstabelecimentoExterno"));
            Property(x => x.PontuacaoMedia, m => m.Column("QtAvaliacaoMedia"));
            //Property(x => x.PontuacaoMedia, m => m.Formula("SELECT SUM()"));
            Bag(x => x.Usuarios, map =>
            {
                map.Table("UsuarioEstabelecimentoFavorito");
                map.Key(z => z.Column("CdEstabelecimento"));
                map.Inverse(false);
            }, a => a.ManyToMany(p => p.Column("CdUsuario")));

            Bag(x => x.Avaliacoes, map =>
            {
                map.Cascade(Cascade.All.Include(Cascade.DeleteOrphans));
                map.Inverse(true);
                map.Key(z => z.Column("CdEstabelecimento"));
            }, c => c.OneToMany());
        }
    }
}