using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using log4net.Core;
using Ticket.API.Shared.Logging;

namespace Ticket.Usuarios.API.Web.Controllers
{
    public class DebugController : ApiController
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(DebugController));

        public IHttpActionResult Get(bool on)
        {
            Level newLevel = Level.Debug;

            Level current = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level;
            _log.Info("Log level atual: " + current);

            if (on)
            {
                DebugSetup.On();
            }
            else
            {
                newLevel = Level.Info;
                DebugSetup.Off();
            }

            if (current != newLevel)
            {
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = newLevel;
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository())
                    .RaiseConfigurationChanged(EventArgs.Empty);
                _log.Info("Novo level: " + newLevel);
            }
            return Ok(on);
        }
    }
}
