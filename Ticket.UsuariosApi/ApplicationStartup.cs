using System;
using System.Diagnostics;
using Nancy.Bootstrapper;

namespace Ticket.UsuariosApi
{
    public class ApplicationStartup : IApplicationStartup
    {
        public void Initialize(IPipelines pipelines)
        {
            Debug.WriteLine("--------------- INITIALIZED-------------");
        }
    }
}
