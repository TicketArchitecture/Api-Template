using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Ticket.API.Shared.Infrastructure;

namespace Ticket.Usuarios.API.Web
{
    public static class APIUnityConfig
    {
        public static void RegisterComponents()
        {
            //se realmente precisarmos de DI...
            //UnityConfig.RegistrarTudo();

            //isto só serve para web API
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(UnityConfig.Container);
        }
    }
}