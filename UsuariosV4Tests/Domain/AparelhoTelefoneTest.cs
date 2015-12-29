using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket.API.Shared.Infrastructure;

namespace UsuariosV4Tests.Domain
{
    [TestClass]
    public class AparelhoTelefoneTest
    {
        [TestMethod]
        public void Nao_Permite_Numero_Invalido()
        {
            try
            {
                var usuarioNovo = new Ticket.Usuarios.API.V4.Domain.AparelhoTelefone("nao numérico",string.Empty,string.Empty);

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
