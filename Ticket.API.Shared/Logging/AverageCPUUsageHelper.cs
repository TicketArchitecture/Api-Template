using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.API.Shared.Logging
{
   public class AverageCPUUsageHelper
    {
        public override string ToString()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            var cpuTimes = searcher.Get()
                .Cast<ManagementObject>()
                .Select(mo => new
                {
                    Name = mo["Name"],
                    Usage = mo["PercentProcessorTime"]
                }
                )
                .ToList();

            return "Average cpu: " + cpuTimes.Where(x => x.Name.ToString() == "_Total").Select(x => x.Usage.ToString()).SingleOrDefault().ToString();
        }
    }
}
