using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVBPS_Project.Response
{
    [Serializable]
    class ScanResponse
    {
        public string permalink { get; set; }
        public int response_code { get; set; }
        public string sha256 { get; set; }
        public string resource { get; set; }
        public string scan_id { get; set; }

        public bool IsMalware()
        {
            return response_code == 1;
        }
    }
}
