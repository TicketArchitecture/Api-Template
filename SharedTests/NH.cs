using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using NHibernate;
using Ticket.API.Shared.Infraestructure.DI;
using NHibernate.Impl;
using Ticket.Usuarios.API.Shared;
using NHibernate.Engine;
using System.Threading;
using System.Threading.Tasks;

namespace SharedTests
{
    [TestClass]
    public class NH
    {
     
        [TestMethod]
        public void Conecta_Ao_DB_e_Obtem_Session()
        {
            //Database.Initialize();
            //UnityConfig.RegistrarTudo();
            var session = Database.OpenSession();
            
            try
            {
                using(var tx = session.BeginTransaction())
                {
                    var teste = tx.IsActive;
                }
            }catch(Exception e)
            {
                Assert.Fail("não foi possível obter uma sessão.");

            }


            Assert.IsInstanceOfType(session, typeof(SessionImpl));
        }

        [TestMethod]
        public void Gera_Sessions_Diferentes_Por_Thread()
        {
            ISessionImplementor sessionA =null;// = new Func<ISessionImplementor>(() => { return  Database.OpenSession().GetSessionImplementation(); }).Invoke();
            ISessionImplementor sessionB = null;// = new Func<ISessionImplementor>(() => { return  Database.OpenSession().GetSessionImplementation(); }).Invoke();

            Task.WaitAll(new Task[2] {Task.Run(() =>
            {
                sessionA = Database.OpenSession().GetSessionImplementation();
            }),

            Task.Run(() => {
                sessionB = Database.OpenSession().GetSessionImplementation();
            })});



            Assert.AreNotEqual(sessionA.SessionId, sessionB.SessionId);
        }

        [TestMethod]
        public void Encerra_Sessao()
        {
            var session = Database.OpenSession();

            session.Close();
         
        }


    }
}
