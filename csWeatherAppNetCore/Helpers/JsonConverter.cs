using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace csWeatherAppNetCore.Helpers
{
    class JsonConverter
    {
        // Deserialize a JSON stream to a object.  
        public static T DeserilizeObject<T>(string json)
        {
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                T deserializedUser = (T)jsonSerializer.ReadObject(memoryStream);
                memoryStream.Close();
                return deserializedUser;
            }
        }
    }
}
