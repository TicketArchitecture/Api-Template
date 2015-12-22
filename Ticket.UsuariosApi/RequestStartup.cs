using System;
using System.Diagnostics;
using Nancy;
using Nancy.Bootstrapper;

namespace Ticket.UsuariosApi
{
    public class RequestStartup : IRequestStartup
    {
        public void Initialize(IPipelines pipelines, NancyContext context)
        {
            Debug.WriteLine("--------------- REQUEST INITIALIZED-------------");
        }
    }
}
