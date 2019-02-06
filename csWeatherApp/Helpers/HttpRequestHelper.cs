using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherApp.Helpers
{
    class HttpRequestHelper
    {
        public static string GetApiRequest(string requestUrl, Dictionary<string, string> parameters)
        {
            WebClient webClient = new WebClient();
            foreach(KeyValuePair<string, string> parameter in parameters)
            {
                webClient.QueryString.Add(parameter.Key, parameter.Value);
            }
            return webClient.DownloadString(requestUrl);
            //var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            //var response = (HttpWebResponse)request.GetResponse();

            //string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //return responseString;
        }
    }
}
