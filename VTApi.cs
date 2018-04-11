using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using PVBPS_Project.Response;
using Newtonsoft.Json;

namespace PVBPS_Project
{
    class VTApi
    {
        private HttpClient client;

        public VTApi()
        {
            this.client = new HttpClient();
        }
		
		//move outside class
        private const string API_KEY = "SECRET_API_KEY";
        private const string RESCAN_URL = @"https://www.virustotal.com/vtapi/v2/file/rescan";

        public ScanResponse ScanByHash(string hash)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["apikey"] = VTApi.API_KEY;
                values["resource"] = hash;

                string responseString = "";

                try
                {
                    var response = client.UploadValues(VTApi.RESCAN_URL, values);
                    responseString = Encoding.Default.GetString(response);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error requesting VT {0}", e.Message);
                }

                ScanResponse scanResponse = JsonConvert.DeserializeObject<ScanResponse>(responseString);
                return scanResponse;
            }
        }

        public ScanReport GetReport(ScanResponse scanResponse)
        {
            using (var client = new WebClient())
            {
                string url = "https://www.virustotal.com/vtapi/v2/file/report?apikey=";
                url += VTApi.API_KEY;
                url += "&resource=" + scanResponse.scan_id;

                var responseString = client.DownloadString(url);

                ScanReport scanReport = JsonConvert.DeserializeObject<ScanReport>(responseString);
                return scanReport;
            }
        }
    }
}
