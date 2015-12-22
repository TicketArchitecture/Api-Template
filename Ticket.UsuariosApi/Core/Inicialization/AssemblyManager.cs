using System;
using System.Reflection;

namespace Ticket.UsuariosApi.Core.Inicialization
{
    internal static class AssemblyManager
    {
        private const string DomainAssembly = "Ticket.UsuariosApi.V1.Domain";
        private const string ApplicationAssembly = "Ticket.UsuariosApi.V1.Application";
        private const string InfrastructureAssembly = "Ticket.UsuariosApi.Infrastructure";

        internal static Assembly GetApplicationAssembly()
        {
            return AppDomain.CurrentDomain.Load(ApplicationAssembly);
        }

        internal static Assembly GetDomainAssembly()
        {
            return AppDomain.CurrentDomain.Load(DomainAssembly);
        }

        internal static Assembly GetInfrastructureAssembly()
        {
            return AppDomain.CurrentDomain.Load(InfrastructureAssembly);
        }
    }
}
