using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket.Usuarios.API.V4;
using Ticket.Usuarios.API.V4.Application.ResourceAssemblers;
using Ticket.Usuarios.API.V4.Representations;

namespace UsuariosV4Tests
{
    [TestClass]
    public class UsuarioResourceAssemblerTest
    {
        private Uri _url = new Uri("http://api.ticket.com.br/usuarios/v4/cadastroFake");
        private UsuarioRepresentation _usuario;

        [TestInitialize]
        public void SetUp()
        {
            _usuario = new UsuarioRepresentation() { AceitoMkt = true, Email = "me@here.com", Id = 123, Nome = "Alex", StatusValidacao = 0 };

        }

        [TestMethod]
        public void Gera_uris()
        {
            
            var assembledUsuario = UsuarioResourceAssembler.AddRelationLinks(_usuario, _url);
            Assert.IsNotNull(assembledUsuario.Links);
        }

        [TestMethod]
        public void Gera_Self_Relation()
        {
            
            var assembledUsuario = UsuarioResourceAssembler.AddRelationLinks(_usuario, _url);
            var list = new List<LinkRelation>(assembledUsuario.Links);
            Assert.IsTrue(list.Exists(x => x.Rel == "self"),"self relation is missing");

        }

        [TestMethod]
        public void Gera_Validacao_Telefone_Relation()
        {

            var assembledUsuario = UsuarioResourceAssembler.AddRelationLinks(_usuario, _url);
            var list = new List<LinkRelation>(assembledUsuario.Links);
            Assert.IsTrue(list.Exists(x => x.Rel == "/rels/usuarios/registrar-numero-telefone"), "'/rels/usuarios/registrar-numero-telefone' relation is missing");

        }

        [TestMethod]
        public void Gera_Validacao_Usuario_Quando_Usuario_Nao_Foi_Validado()
        {
            _usuario.StatusValidacao = 0;
            var assembledUsuario = UsuarioResourceAssembler.AddRelationLinks(_usuario, _url);
            var list = new List<LinkRelation>(assembledUsuario.Links);
            Assert.IsTrue(list.Exists(x => x.Rel == "/rels/usuarios/validacao"), "'/rels/usuarios/validar' relation is missing");

        }

        [TestMethod]
        public void Gera_Relation_Cartoes()
        {
            var assembledUsuario = UsuarioResourceAssembler.AddRelationLinks(_usuario, _url);
            var list = new List<LinkRelation>(assembledUsuario.Links);
            Assert.IsTrue(list.Exists(x => x.Rel == "/rels/usuarios/listar-cartoes"), "'/rels/usuarios/listar-cartoes' relation is missing");

        }


        [TestMethod]
        public void Gera_Relation_Criar_Cartao()
        {
            var assembledUsuario = UsuarioResourceAssembler.AddRelationLinks(_usuario, _url);
            var list = new List<LinkRelation>(assembledUsuario.Links);
            Assert.IsTrue(list.Exists(x => x.Rel == "/rels/usuarios/adicionar-cartao"), "'/rels/usuarios/adicionar-cartao' relation is missing");

        }
    }
}
