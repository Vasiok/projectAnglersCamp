using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BLL
{
    public class WaterLevelJson
    {

        private string requestUrl = "https://www.kimonolabs.com/api/akiwh40e?apikey=JBiO2jxJiVxwMOppFyDVxaw2YTgc3TY7";

        public string Response { get; set; }

        public WaterLevelJson()
        {
            Response = GET(requestUrl);
        }


        public List<JSONModel> GetFromKimono()
        {
            List<JSONModel> readings = new List<JSONModel>();

            JObject objectsFromKimono = JObject.Parse(Response);
            IList<JToken> results = objectsFromKimono["results"]["WaterLevel"].Children().ToList();

            foreach (JToken token in results)
            {
                JSONModel model = JsonConvert.DeserializeObject<JSONModel>(token.ToString());
                readings.Add(model);
            }

            return readings;
        }



        public string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

    }


    public class JSONModel
    {
        public string WaterBody { get; set; }
        public string County { get; set; }
        public string WaterLevel { get; set; }
        public Name  Name { get; set; }
    }

    public class Name
    {
        public string href { get; set; }
        public string text { get; set; }
    }
}
