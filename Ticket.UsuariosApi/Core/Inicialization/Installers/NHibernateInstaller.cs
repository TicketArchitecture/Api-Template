using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Context;

namespace Ticket.UsuariosApi.Core.Inicialization.Installers
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISessionFactory>()
                                 .UsingFactoryMethod(BuildSessionFactory));

            container.Register(Component.For<ISession>()
                .UsingFactoryMethod(() => container.Resolve<ISessionFactory>().OpenSession())
                       .LifestylePerThread());

        }

        public static ISessionFactory BuildSessionFactory(IKernel kernel)
        {
            var configure = Fluently.Configure();

            configure.Database(IsDebug()
                ? MsSqlConfiguration.MsSql2008.ConnectionString(GetConnectionString()).ShowSql().FormatSql()
                : MsSqlConfiguration.MsSql2008.ConnectionString(GetConnectionString()));

            configure.Mappings(map =>
            {
                map.FluentMappings.Conventions.Setup(x => x.Add(AutoImport.Never()));
                map.FluentMappings.AddFromAssemblyOf<Infrastructure.Mappings.UsuarioV1Map>();

            });

            configure.CurrentSessionContext<CallSessionContext>();

            //_sessionFactory =configure.BuildSessionFactory();
            //return _sessionFactory;

            return configure.BuildSessionFactory();
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        private static bool IsDebug()
        {
            #if (DEBUG)
                  return true;

            #elif(TRACE)
                return false;
            #endif
        }
    }
}
