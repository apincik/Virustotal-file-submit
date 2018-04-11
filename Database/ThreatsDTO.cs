using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVBPS_Project.Database
{
    [Serializable]
    class ThreatsDTO
    {
        public List<ThreatDTO> threats {get; set;}

        public ThreatsDTO()
        {
            threats = new List<ThreatDTO>();
        }
    }
}
