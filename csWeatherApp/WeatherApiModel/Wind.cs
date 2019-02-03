using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherApp.WeatherApiModel
{
    [DataContract]
    class Wind
    {
        /// <summary>
        /// Winds speed in meter/second
        /// </summary>
        [DataMember(Name = "speed")]
        public double Speed { get; private set; }

        /// <summary>
        ///  Wind direction in degrees
        /// </summary>
        [DataMember(Name = "deg")]
        public double Degree { get; private set; }
    }
}
