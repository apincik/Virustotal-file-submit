using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVBPS_Project.Response
{
    [Serializable]
    class ScanReport
    {
       
        public Dictionary<string, ScanSoftware> scans { get; set; }

        public ScanReport()
        {
            scans = new Dictionary<string, ScanSoftware>();
        }

        public string DetectionResultToString()
        {
            int detectedCount = 0;
            foreach(KeyValuePair<string, ScanSoftware> scan in scans)
            {
                if(scan.Value.detected)
                {
                    detectedCount++;
                }
            }

            return detectedCount.ToString() + " / " + scans.Count().ToString();
        }
    }
}
