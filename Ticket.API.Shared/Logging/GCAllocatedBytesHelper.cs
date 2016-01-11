using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.API.Shared.Logging
{
    public class GCAllocatedBytesHelper
    {
        public override string ToString()
        {
            
            return GC.GetTotalMemory(true).ToString();
        }
    }
}
