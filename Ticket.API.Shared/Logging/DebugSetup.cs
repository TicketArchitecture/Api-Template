using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Ticket.API.Shared.Logging
{
    public static class DebugSetup
    {
        public static void On()
        {

            GlobalContext.Properties["GCAllocatedBytesHelper"] = new GCAllocatedBytesHelper();
            GlobalContext.Properties["AverageCPUUsageHelper"] = new AverageCPUUsageHelper();
            GlobalContext.Properties["CPUUsageHelper"] = new CPUUsageHelper();
            GlobalContext.Properties["DiskUsageHelper"] = new DiskUsageHelper();
        }

        public static void Off()
        {
            GlobalContext.Properties["GCAllocatedBytesHelper"] = String.Empty;
            GlobalContext.Properties["AverageCPUUsageHelper"] = String.Empty;
            GlobalContext.Properties["CPUUsageHelper"] = String.Empty;
            GlobalContext.Properties["DiskUsageHelper"] = String.Empty;
        }
    }
}
