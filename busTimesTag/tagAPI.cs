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
    public class tagAPI//https://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm
    {
        public static List<busStop> GetData(string latitude, string longitude, string meters)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            // Create a request for the URL. 	
            string url = "https://data.metromobilite.fr/api/linesNear/json?x=" + latitude + "&y=" + longitude + "&dist=" + meters + "&details=true";
            Console.WriteLine(url);
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials. Not mandatory
            //request.Credentials = CredentialCache.DefaultCredentials;//not mandatory
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            List<busStop> stops = JsonConvert.DeserializeObject<List<busStop>>(responseFromServer);//https://www.newtonsoft.com/json/help/html/DeserializeCollection.htm
            return stops;
        }

    }
}
