using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PVBPS_Project.Database
{
    /**
     * Simple file DB storing data in JSON 
     */
    class JsonDatabase
    {
        private ThreatsDTO threats;

        private const string PATH = "database.json";

        public JsonDatabase()
        {
            string fileContent = File.ReadAllText(PATH); //NEED FILE ...json in debug/build folder !!!
            threats = JsonConvert.DeserializeObject<ThreatsDTO>(fileContent);

            if(threats == null)
            {
                threats = new ThreatsDTO();
            }

        }

        public ThreatDTO GetByHash(string hash)
        {
            if(threats == null)
            {
                return null;
            }

            foreach (ThreatDTO threat in threats.threats)
            {
                if (threat.hash == hash)
                {
                   return threat;
                }
            }

            return null;
        }

        public bool Insert(ScanItem scanItem)
        {
            if(GetByHash(scanItem.GetHash()) != null)
            {
                return false;
            }

            ThreatDTO threat = new ThreatDTO();
            threat.isMalware = scanItem.scanResult != null ? scanItem.scanResult.IsMalware() : false;
            threat.rate = scanItem.reportResult != null ? scanItem.reportResult.DetectionResultToString() : "0/0";
            threat.hash = scanItem.GetHash();

            threats.threats.Add(threat);
            Save();

            return true;
        }

        public bool Save()
        {
            File.WriteAllText(PATH, Newtonsoft.Json.JsonConvert.SerializeObject(threats));
            return true;
        }
    }
}
