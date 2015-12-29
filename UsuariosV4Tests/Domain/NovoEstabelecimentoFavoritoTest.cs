using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket.API.Shared.Infrastructure;

namespace UsuariosV4Tests.Domain
{
    [TestClass]
    public class NovoEstabelecimentoFavoritoTest
    {
        [TestMethod]
        public void Nao_Permite_Id_Invalido()
        {
            try
            {
                var estabelecimentoFavorito = new Ticket.Usuarios.API.V4.Domain.NovoEstabelecimentoFavorito(-1, 1);

            }
            catch (BusinessException be)
            {
                //OK
            }
            catch (Exception e)
            {
                Assert.Fail("Excessão não esperada");
            }

            try
            {
                var estabelecimentoFavorito = new Ticket.Usuarios.API.V4.Domain.NovoEstabelecimentoFavorito(-1);

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


        [TestMethod]
        public void Nao_Permite_Nota_Invalida()
        {
            try
            {
                var estabelecimentoFavorito = new Ticket.Usuarios.API.V4.Domain.NovoEstabelecimentoFavorito(1, -1);

            }
            catch (BusinessException be)
            {
                //OK
            }
            catch (Exception e)
            {
                Assert.Fail("Excessão não esperada");
            }


            try
            {
                var estabelecimentoFavorito = new Ticket.Usuarios.API.V4.Domain.NovoEstabelecimentoFavorito(1, 6);

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
