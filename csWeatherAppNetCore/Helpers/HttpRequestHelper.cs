using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherAppNetCore.Helpers
{
    class HttpRequestHelper
    {
        public static string GetApiRequest(string requestUrl, Dictionary<string, string> parameters)
        {
            var webClient = new WebClient();
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                webClient.QueryString.Add(parameter.Key, parameter.Value);
            }
            return webClient.DownloadString(requestUrl);
        }
    }
}
