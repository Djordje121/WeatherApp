using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace csWeatherApp
{
    class Program
    {
        static void Main()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?id=3194360&appid=803c3618a46f951af1c34f1662e3939c");

            var response = (HttpWebResponse)request.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine(responseString);
            Console.WriteLine("..........................");


            Test w = ReadToObject(responseString);
            Console.WriteLine(w.id + " " + w.name + " " + w.cod);
            Console.WriteLine(w.coord.lat + " " + w.coord.lon);
           
            Console.ReadLine();
        }

     

        // Deserialize a JSON stream to a User object.  
        public static Test ReadToObject(string json)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Test));
            Test deserializedUser = ser.ReadObject(ms) as Test;
            ms.Close();
            return deserializedUser;
        }
    }

    [DataContract]
    class Test
    {
        [DataMember]
        public coord coord;

        [DataMember]
        public double id;

        [DataMember]
        public string name;

        [DataMember]
        public string cod;

     
    }

    [DataContract]
    public class coord
    {
        [DataMember]
        public double lon;

        [DataMember]
        public double lat;
    }
}
