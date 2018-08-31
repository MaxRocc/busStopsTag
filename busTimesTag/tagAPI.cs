using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace busTimesTag
{
    public class tagAPI
        //https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
        //https://www.newtonsoft.com/json/help/html/DeserializeCollection.htm

    {
        private IRequestAPI _request;

        public tagAPI()
        {
            _request = new RequestAPI();
        }

        public tagAPI(IRequestAPI request)
        {
            _request = request;
        }

        public List<LinesNearData> GetData(string latitude, string longitude, string meters)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            // Create a request for the URL. 	
            string baseUrl = "https://data.metromobilite.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details=true";
            string urltest = String.Format(baseUrl, latitude, longitude, meters);
            //previous line equals to : string url = "https://data.metromobilite.fr/api/linesNear/json?x=" + latitude + "&y=" + longitude + "&dist=" + meters + "&details=true";

            string responseFromServer = _request.DoRequest(urltest);

            List<LinesNearData> stops = JsonConvert.DeserializeObject<List<LinesNearData>>(responseFromServer);          

            return stops;
        }
        public Dictionary<string, List<string>> ConvertObjToDico(List<LinesNearData> stops) {
            Dictionary<string, List<string>> monDico = new Dictionary<string, List<string>>();

            //List<string> a = monDico["key"];//demo by Olivier
            //string c = "lkj54";//demo by Olivier
            //List<string> b = new List<string> { "mtrhtrzhlh", "ljhbv" };//demo by Olivier
            //monDico["key"].Add(c);//demo by Olivier
            //monDico["key"].AddRange(b);//demo by Olivier

            foreach (LinesNearData stop in stops)
            {
                if (!monDico.ContainsKey(stop.name))
                {
                    monDico.Add(stop.name, stop.lines);
                }
                else
                {
                    monDico[stop.name].AddRange(stop.lines);
                }
                //Console.WriteLine(stop.name);
            }
            return monDico;
        }
        public void DisplayMonDico(Dictionary<string, List<string>> monDico)
        {
            foreach (KeyValuePair<String, List<string>> item in monDico)
            {
                Console.WriteLine(item.Key);
                foreach (var line in item.Value)
                {
                Console.WriteLine(line);
                }
            }
        }
    }
}
