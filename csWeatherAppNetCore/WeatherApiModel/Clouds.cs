using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherAppNetCore.WeatherApiModel
{
    [DataContract]
    class Clouds
    {
        /// <summary>
        ///  Cloudiness level in percentage
        /// </summary>
        [DataMember (Name = "all")]
        public double Cloudiness { get; private set; }
    }
}
