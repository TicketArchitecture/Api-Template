using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket.API.Shared.Infrastructure;

namespace UsuariosV4Tests.Domain
{
    [TestClass]
    public class UsuarioNovoTest
    {

        [TestMethod]
        public void Nao_Aceita_Nome_Curto_Demais()
        {
            var nomeCurto = "A";
            var emailValido = "algumnome@algum.dominio.br";

            try
            {
                var usuarioNovo = new Ticket.Usuarios.API.V4.Domain.UsuarioDadosMinimos(nomeCurto, emailValido,true);

            }catch(BusinessException be)
            {
                //OK
            }
            catch(Exception e)
            {
                Assert.Fail("Excessão não esperada");
            }
        }


        [TestMethod]
        public void Nao_Aceita_Email_Invalido()
        {
            var nomeValido = "Ticket Servicos SA";
            var emailInvalido = String.Empty;

            try
            {
                var usuarioNovo = new Ticket.Usuarios.API.V4.Domain.UsuarioDadosMinimos(nomeValido, emailInvalido, true);

            }
            catch (BusinessException be)
            {
                //OK
            }
            catch (Exception e)
            {
                Assert.Fail("Excessão não esperada");
            }
        }
    }
}
