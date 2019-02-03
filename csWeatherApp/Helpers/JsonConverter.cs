using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace csWeatherApp.Helpers
{
    class JsonConverter
    {
        // Deserialize a JSON stream to a object.  
        public static T DeserilizeObject<T>(string json)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            T deserializedUser = (T)ser.ReadObject(ms);
            ms.Close();
            return deserializedUser;
        }
    }
}
