using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket.API.Shared.Infrastructure;
using Ticket.API.Shared.Infrastructure;

namespace SharedTests
{
    [TestClass]
    public class BusinessValidatorTest
    {
        [TestMethod]
        public void Lanca_Business_Exception_Com_Texto_De_Resource_File()
        {
            var listaErro = new List<string>();
            listaErro.Add("Shared.Tests");
            var textoEsperado = "Texto de Teste.";
            var textoRecebido = string.Empty;

            try
            {
                BusinessValidator.ThrowBusinessExceptionIfNeeded(listaErro);
            }catch(BusinessException be)
            {
                (be.Data as Dictionary<string,string>).TryGetValue("Shared.Tests",out textoRecebido);
            }

            Assert.AreEqual(textoEsperado, textoRecebido);
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Lanca_Business_Exception_Quando_Ha_Item_Lista_De_Erros()
        {
            var listaErro = new List<string>();
            listaErro.Add("Shared.Tests");
            BusinessValidator.ThrowBusinessExceptionIfNeeded(listaErro);
        }


        [TestMethod]
        public void Lanca_Business_Exception_Com_Texto_Padrao_Quando_Resource_Nao_Existe()
        {
            var listaErro = new List<string>();
            listaErro.Add("Resource Inexistente");
            var textoEsperado = "Esta é uma mensagem de erro padrão. Verifique se utilizou o nome correto do Resource.";
            var textoRecebido = string.Empty;

            try
            {
                BusinessValidator.ThrowBusinessExceptionIfNeeded(listaErro);
            }
            catch (BusinessException be)
            {
                (be.Data as Dictionary<string, string>).TryGetValue("Resource Inexistente", out textoRecebido);
            }

            Assert.AreEqual(textoEsperado, textoRecebido);
        }


        [TestMethod]
        public void Nao_Lanca_Business_Exception_Com_Lista_De_Erros_Vazia()
        {
            var listaErro = new List<string>();
        
            BusinessValidator.ThrowBusinessExceptionIfNeeded(listaErro);
     
        }


    }
}
