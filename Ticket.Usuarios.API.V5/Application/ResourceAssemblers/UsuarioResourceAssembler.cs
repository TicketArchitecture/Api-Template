using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Usuarios.API.V5.Representations;

namespace Ticket.Usuarios.API.V5.Application.ResourceAssemblers
{
    public static class UsuarioResourceAssembler
    {
        public static UsuarioRepresentation AddRelationLinks(UsuarioRepresentation usuario, Uri requestUri)
        {
            usuario.Links = new List<LinkRelation>(GetLinks(usuario, requestUri));
            return usuario;
        }


        private static IEnumerable<LinkRelation> GetLinks(UsuarioRepresentation usuario, Uri requestUri)
        {
     
            //relations sempre disponíveis:
            yield return Self(usuario);
            yield return ValidarTelefone(usuario);
            yield return ListarCartoes(usuario);
            yield return AdicionarCartao(usuario);
            yield return AdicionarFavorito(usuario);
            yield return ListarFavoritos(usuario);
            yield return ListarCategoriasEstabelecimentos();
            yield return GeoLocalizarEstabelecimento();
            yield return ValidarEmailUsuarios();


            if (usuario.StatusValidacao == 0)
                yield return ValidarUsuario(usuario);
            
                    
        }


       
        private static string UriUsuarioComId(UsuarioRepresentation usuario)
        {
            var uri = String.Concat(Version.FullAPIEndpoint, usuario.Id);
            return uri;
        }

        private static string UriUsuarioIdComSegmentoComplementar(string segmento,UsuarioRepresentation usuario)
        {
            return String.Concat(UriUsuarioComId(usuario),"/",segmento);
        }

        private static LinkRelation Self(UsuarioRepresentation usuario)
        {
            var uri = new Uri(UriUsuarioComId(usuario));
            var self = new LinkRelation(uri);

            return self; 

        }

        private static LinkRelation ValidarUsuario(UsuarioRepresentation usuario)
        {
            var uriValidacao = new Uri(UriUsuarioIdComSegmentoComplementar("validacao",usuario));
            var validacao = new LinkRelation("usuarios/validacao", uriValidacao);
            return validacao;
        }

        private static LinkRelation ValidarTelefone(UsuarioRepresentation usuario)
        {
            var uriValidarTelefone = new Uri(UriUsuarioIdComSegmentoComplementar("validacao-telefone",usuario));
            var validarTelefone = new LinkRelation("usuarios/registrar-numero-telefone", uriValidarTelefone);

            return validarTelefone;
        }

        private static LinkRelation ListarCartoes(UsuarioRepresentation usuario)
        {
            var cartoes = new Uri(UriUsuarioIdComSegmentoComplementar("cartoes",usuario));
            var listarCartoes = new LinkRelation("usuarios/listar-cartoes", cartoes);

            return listarCartoes;
        }

        private static LinkRelation AdicionarCartao(UsuarioRepresentation usuario)
        {
            var cartoes = new Uri(UriUsuarioIdComSegmentoComplementar("cartoes", usuario));
            var listarCartoes = new LinkRelation("usuarios/adicionar-cartao", cartoes);
            return listarCartoes;
        }

        private static LinkRelation AdicionarFavorito(UsuarioRepresentation usuario)
        {
            var favoritos = new Uri(UriUsuarioIdComSegmentoComplementar("favoritos", usuario));
            var listaFavoritos = new LinkRelation("usuarios/adicionar-favorito", favoritos);
            return listaFavoritos;
        }

        private static LinkRelation ListarFavoritos(UsuarioRepresentation usuario)
        {
            var favoritos = new Uri(UriUsuarioIdComSegmentoComplementar("favoritos", usuario));
            var listaFavoritos = new LinkRelation("usuarios/listar-favoritos", favoritos);
            return listaFavoritos;
        }

        private static LinkRelation ListarCategoriasEstabelecimentos()
        {
            var uri = new Uri(ApiEstabelecimentos.EstabelecimentosComComplemento("categorias"));
            var linkRelation = new LinkRelation("estabelecimentos/listar-categorias", uri);
            return linkRelation;
        }

        private static LinkRelation GeoLocalizarEstabelecimento()
        {
            var uri = new Uri(ApiEstabelecimentos.EstabelecimentosComComplemento("localizacao"));
            var linkRelation = new LinkRelation("estabelecimentos/geolocalizar-estabelecimento", uri);
            return linkRelation;
        }

        private static LinkRelation ValidarEmailUsuarios()
        {
            var uri = new Uri(Version.UsuariosComComplemento("validacao-email"));
            var linkRelation = new LinkRelation("usuarios/validar-email", uri);
            return linkRelation;
        }


    }
}
