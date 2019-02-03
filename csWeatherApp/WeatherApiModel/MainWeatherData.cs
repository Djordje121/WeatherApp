using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherApp.WeatherApiModel
{
    [DataContract]
    class MainWeatherData
    {
        /// <summary>
        ///  Temperature in degree celsius 
        /// </summary>
        [DataMember (Name = "temp")]
        public double Temperature { get; private set; }

        /// <summary>
        ///  Pressure in hectopascal (hPA)
        /// </summary>
        [DataMember (Name = "pressure")]
        public double Pressure { get; private set; }
        
        /// <summary>
        /// Humidity in percentage
        /// </summary>
        [DataMember (Name = "humidity")]
        public double Humidity { get; private set; }

        /// <summary>
        ///  Min daily in degree celsius 
        /// </summary>
        [DataMember (Name = "temp_min")]
        public double MinDailyTemperature { get; private set; }

        /// <summary>
        ///  Max daily in degree celsius 
        /// </summary>
        [DataMember (Name = "temp_max")]
        public double MaxDailyTemperature { get; private set; }
    }
}
