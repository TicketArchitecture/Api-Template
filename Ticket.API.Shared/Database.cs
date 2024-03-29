﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using log4net.Core;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using Ticket.API.Shared.NH;

namespace Ticket.API.Shared
{
    public static class Database
    {
        public static ISessionFactory Factory { get; private set; }
        private static ILog _log = LogManager.GetLogger(typeof(Database));

        static Database()
        {
            try
            {
                var config = new Configuration();
                config.Configure();

                var mapper = new ModelMapper();
                mapper.AddMappings(GetAllMappingTypes());

                var compileMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                compileMapping.autoimport = false;
                config.AddMapping(compileMapping);

                Factory = config.BuildSessionFactory();
            }
            catch (Exception e)
            {
                _log.Fatal(e);
                throw;
            }
        }

        public static ISession OpenSession()
        {
            ISession session;
            //veja no config do NH que tipo de contexto está sendo usado:
            //"call", "thread_static", "web" and "wcf_operation"
            //exemplo:  <property name="current_session_context_class">thread_static</property>

            if (NHibernate.Context.CurrentSessionContext.HasBind(Factory))
            {
                session = Factory.GetCurrentSession();
            }
            else
            {
#if DEBUG
                session = Factory.OpenSession(new SQLDebugOutputLogger());

#else
                session = Factory.OpenSession();

#endif
                NHibernate.Context.CurrentSessionContext.Bind(session);
            }

            return session;
        }



        public static ISession Session
        {
            get { return Factory.GetCurrentSession(); }
        }

        public static void CloseSession()
        {
            _log.Debug("Entity instances on Session: " + Session.Statistics.EntityCount);
            Factory.GetCurrentSession().Close();
        }
       
        private static IEnumerable<Assembly> TicketAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName.StartsWith("Ticket.Usuarios.API.V"))
                {
                    if (_log.IsDebugEnabled)
                        _log.Debug("NH Mapping Assembly adicionado: " + assembly.ToString());

                    yield return assembly;
                }
            }

        }

        private static List<Type> GetAllMappingTypes()
        {
            var ticketAssemblies = TicketAssemblies();
            var tipos = new List<Type>();
            foreach (var assembly in ticketAssemblies)
                tipos.AddRange(assembly.ExportedTypes.Where(x => x.Namespace.Contains(".Mappings")));

            if (_log.IsDebugEnabled)
                foreach (var clazz in tipos)
                    _log.Debug("NH mapping adicionado: " + clazz.FullName);

            return tipos;
        }

    }
}



