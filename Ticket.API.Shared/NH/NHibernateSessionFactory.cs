
using System;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Automapping;
using System.Collections.Generic;
using System.Collections;

namespace Ticket.API.Shared.NH
{
    /// <summary>
    /// Factory para criação da SessionFactory do NHibernate
    /// </summary>
    public class NHibernateSessionFactory
    {
        /// <summary>
        /// Configuração do NHibernate
        /// </summary>
        public ISessionFactory Factory { get; private set; }

        /// <summary>
        /// Cria uma nova configuração do NHibernate para a aplicação
        /// </summary>
        public NHibernateSessionFactory()
        {

            Configuration configuration =
                Fluently.Configure().Database(SQLiteConfiguration.Standard.UsingFile("App_Data/demo.db").Driver<NHibernate.Driver.SQLite20Driver>())
                    .Mappings(m =>
                        {
                            m.FluentMappings.Conventions.Setup(x => x.Add(AutoImport.Never()));

                            foreach (var assembly in MappingAssemblies())
                            {
                                m.FluentMappings.AddFromAssembly(assembly);
                            }
                        })
                        .ExposeConfiguration(c =>
                        {
                            c.SetProperty("adonet.batch_size", "1");
                        }).BuildConfiguration();
            Factory = configuration.BuildSessionFactory();
        }

        private static IEnumerable<Assembly> MappingAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                //baseando-nos na convenção de que cada Fluent Mapping está
                //no ns 'infrastructure' de cada versão
                if (assembly.FullName.StartsWith("Ticket.Usuarios.API.V"))
                    yield return assembly;
            }

        }

    }
}
