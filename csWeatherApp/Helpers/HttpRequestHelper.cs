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
        public static string GetApiRequest(string requestUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            var response = (HttpWebResponse)request.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
