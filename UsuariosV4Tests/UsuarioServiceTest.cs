using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket.API.Shared;
using Ticket.Usuarios.API.V4.Application;
using Ticket.Usuarios.API.V4.Application.Commands;

namespace UsuariosV4Tests
{
    [TestClass]
    public class UsuarioServiceTest
    {
        [TestInitialize]
        public void Start()
        {
            //forçando carregamento do assembly que contém os mappings do nh
            var novoUsuario = new NovoUsuarioCommand(aceitoMkt: true, email: "", nome: "");

            Database.OpenSession();
        }

        [TestMethod]
        public void Deve_Criar_Usuario_Basico()
        {
            var novoUsuario = new NovoUsuarioCommand(aceitoMkt:true, email:"eu@ticket.com",nome:"developer" );

            //excluindo usuário pré existente
            Database.Session.Delete(@"from Usuario u where u.Email = 'eu@ticket.com'");
            Database.Session.Flush();

            //somente nos testes unitários é necessário gerenciar a transação,
            //já que os controllers básicos utilizam o action filter *UseTransactionsByDefaultAttribute
            using (var tx = Database.Session.BeginTransaction()) {

                var novo = new UsuarioService().CriarNovoUsuario(novoUsuario);
                tx.Commit();
                Assert.IsTrue(novo.Id > 0);
            }

            
        }
    }
}
