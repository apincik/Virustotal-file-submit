using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVBPS_Project.Database
{
    [Serializable]
    class ThreatDTO
    {
        public string hash { get; set; }
        public bool isMalware { get; set; }
        public string rate { get; set; }
    }
}
