using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVBPS_Project.Response
{
    [Serializable]
    class ScanSoftware
    {
        public bool detected { get; set; }
        public string version { get; set; }
        public string result { get; set; }
        public string update { get; set; }
    }
}
