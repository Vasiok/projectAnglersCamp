using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsJson
    {

         private string requestUrl = "https://www.kimonolabs.com/api/akdgi45e?apikey=JBiO2jxJiVxwMOppFyDVxaw2YTgc3TY7";

        public string Response { get; set; }

        public NewsJson()
        {
            Response = GET(requestUrl);
        }


        public List<JSONNewsModel> GetFromKimono()
        {
            List<JSONNewsModel> readings = new List<JSONNewsModel>();

            JObject objectsFromKimono = JObject.Parse(Response);
            IList<JToken> results = objectsFromKimono["results"]["fishingireland"].Children().ToList();

            foreach (JToken token in results)
            {
                JSONNewsModel model = JsonConvert.DeserializeObject<JSONNewsModel>(token.ToString());
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


    public class JSONNewsModel
    {
        public LastNews lastNews { get; set; }
    }

    public class LastNews
    {
        public string href { get; set; }
        public string text { get; set; }
    }

    //}
}
