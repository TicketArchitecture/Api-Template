using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NHibernate;
using Ticket.API.Shared.NH;
using Ticket.Usuarios.API.Shared;

namespace Ticket.API.Shared.Infraestructure.DI
{
    public static class UnityConfig
    {
        private static IUnityContainer _container = new UnityContainer();

        public static IUnityContainer Container
        {
            get { return _container; }
            private set { _container = value; }
        }


        //inclua aqui novos namespaces para registro automático
        private static string[] _nameSpacesParaExtracaoDeClassesARegistrar = new[]
        {
            ".Infrastructure.Repositories",
            ".Application"
        };
        

        public static void RegistrarTudo()
        {
           
            Container.RegisterType<ISession>(
                new ContainerControlledLifetimeManager(),
            new InjectionFactory(c => Database.OpenSession()));

            //Container.RegisterType<IStatelessSession>(
            //    new ContainerControlledLifetimeManager(),
            //new InjectionFactory(c => Database.OpenStatelessSession()));

            AutoRegistrar();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(Container));
        }

        private static void AutoRegistrar()
        {
            var implementacoesDeInteresse = ImplementacoesDeInteresse();
            Container.RegisterTypes(implementacoesDeInteresse,
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);
        }

       
        private static IEnumerable<Type> ImplementacoesDeInteresse()
        {
            var ticketTypes = GetAllTypes();
            foreach (var tipo in ticketTypes)
            {
                if (EstaEmNamespaceDeInteresse(tipo))
                    yield return tipo;
            }
        }

        private static bool EstaEmNamespaceDeInteresse(Type tipo)
        {
            foreach(var ns in _nameSpacesParaExtracaoDeClassesARegistrar)
                if (!tipo.IsInterface && tipo.Namespace.Contains(ns))
                    return true;
            return false;
        }

        private static IEnumerable<Assembly> TicketAssemblies()
        {
            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName.StartsWith("Ticket.Usuarios"))
                    yield return assembly;
            }

        }

        private static List<Type> GetAllTypes()
        {
            var ticketAssemblies = TicketAssemblies();
            var tipos = new List<Type>();
            foreach (var assembly in ticketAssemblies)
                tipos.AddRange(assembly.ExportedTypes);
            return tipos;
        }


    }
}

