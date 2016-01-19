using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Ticket.API.Shared.Filters
{
    public class DebugLogMessageFilter : DelegatingHandler
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(DebugLogMessageFilter));

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //99% das vezes...
            if (!_log.IsDebugEnabled)
                return await base.SendAsync(request, cancellationToken);

            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                using (Stream stream = new MemoryStream())
                {
                    await response.Content.CopyToAsync(stream);
                    _log.Debug("Response size (bytes): " + stream.Length);
                }
            }
            return response;
        }
    }
}
