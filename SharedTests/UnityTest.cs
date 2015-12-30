using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Ticket.Usuarios.API.V4.Domain.Repositories;
using Microsoft.Practices.Unity;
using Ticket.API.Shared.Infrastructure;
using Ticket.Usuarios.API.V4.Application.Contracts;
using Ticket.Usuarios.API.V4.Application;

namespace SharedTests
{
    [TestClass]
    public class UnityTest
    {
        [TestInitialize]
        public void LoadAssemblies()
        {
            var assemblyFile = Path.Combine(Environment.CurrentDirectory, "Ticket.Usuarios.API.V4.dll");
            Assembly.LoadFrom(assemblyFile);
        }

        [TestMethod]
        public void Registra_Tipos_E_Interfaces()
        {
            //TODO: criar assembly, classe e interface via reflection para testar.
            UnityConfig.RegistrarTudo();
            var usuarioService = UnityConfig.Container.Resolve<IUsuarioService>();

            Assert.IsInstanceOfType(usuarioService, typeof(UsuarioService));

        }
    }
}
