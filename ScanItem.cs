using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVBPS_Project.Response;

namespace PVBPS_Project
{
    class ScanItem
    {
        private string file;

        private string hash;

        private List<string> threats;

        public ScanResponse scanResult;

        public ScanReport reportResult;

        public string stringResult = "";

        public ScanItem(string file, string hash)
        {
            this.file = file;
            this.hash = hash;
        }

        public void AddThreat(string threatName)
        {
            threats.Add(threatName);
        }

        public List<string> GetThreads()
        {
            return this.threats;
        }

        public string GetHash()
        {
            return this.hash;
        }

        public string GetFilename()
        {
            return this.file;
        }
    }
}
