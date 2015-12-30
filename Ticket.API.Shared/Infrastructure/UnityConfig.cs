using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NHibernate;

namespace Ticket.API.Shared.Infrastructure
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
            ".Application"
        };
        

        public static void RegistrarTudo()
        {
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

