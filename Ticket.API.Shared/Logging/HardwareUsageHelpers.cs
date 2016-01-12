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

            return " " + cpuTimes.Where(x => x.Name.ToString() == "_Total").Select(x => x.Usage.ToString()).SingleOrDefault().ToString();
        }
    }

    public class CPUUsageHelper
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

            StringBuilder times = new StringBuilder();
            foreach (var time in cpuTimes)
            {
                if (time.Name.Equals("_Total"))
                    continue;   
                times.AppendFormat(" #{0} {1}%", time.Name, time.Usage);
            }

            return times.ToString();
        }
    }

    public class GCAllocatedBytesHelper
    {
        public override string ToString()
        {

            return GC.GetTotalMemory(true).ToString();
        }
    }

    public class DiskUsageHelper
    {
        private static readonly List<string> _interestingData = InterestingData();

        public override string ToString()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfDisk_PhysicalDisk");

            var namespacePath = "\\\\.\\ROOT\\cimv2";
            var className = "Win32_PerfFormattedData_PerfDisk_PhysicalDisk";

            var managementClass = new ManagementClass(namespacePath + ":" + className);
            PropertyDataCollection dataCollection = null;

            foreach (ManagementObject manObj in managementClass.GetInstances())
            {
                if (manObj.Path.Path.EndsWith("\"_Total\""))
                    continue;
                dataCollection = manObj.Properties;

            }


            return FullMessage(dataCollection);
            
        }

        private static List<string> InterestingData()
        {
            var list = new List<string>();

            //from https://msdn.microsoft.com/en-us/library/aa394262%28v=vs.85%29.aspx
            list.Add("AvgDiskReadQueueLength");
            list.Add("AvgDiskSecPerRead");
            list.Add("AvgDiskSecPerWrite");
            list.Add("AvgDiskWriteQueueLength");

            return list;
        }

        private string FullMessage(PropertyDataCollection rawData)
        {
            var buffer = new StringBuilder();
            foreach(var item in _interestingData)
            {
                buffer.AppendFormat(" {0} {1}", item, rawData[item].Value.ToString());
            }
            return buffer.ToString();
        }
    }


}
