using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;
using System.IO;
using System.Threading;
using System.Configuration;
using csWeatherAppNetCore.Helpers;
using csWeatherAppNetCore.Interfaces;

namespace csWeatherAppNetCore.WeatherApiModel
{
    /// <summary>
    ///  Used for storing web api weather response
    /// </summary>
    [DataContract]
    class WeatherData : EventArgs
    {
        /// <summary>
        /// City id
        /// </summary>
        [DataMember(Name = "id")]
        public double CityId { get; private set; }

        /// <summary>
        /// City id
        /// </summary>
        [DataMember(Name = "name")]
        public string CityName { get; private set; }

        /// <summary>
        /// Visibility in meters 
        /// </summary>
        [DataMember(Name = "visibility")]
        public double Visibility { get; private set; }

        /// <summary>
        /// Internal server parameter
        /// </summary>
        [DataMember(Name = "cod")]
        public string Cod { get; private set; }

        /// <summary>
        /// Datetime of response calculation
        /// </summary>
        [DataMember(Name = "dt")]
        public double DateCalculated { get; private set; }

        /// <summary>
        /// City coordinates
        /// </summary>
        [DataMember(Name = "coord")]
        public Coordinates Coordinates { get; private set; }

        /// <summary>
        /// Weather condtion data
        /// </summary>
        [DataMember(Name = "weather")]
        public List<Weather> WeatherList { get; private set; }

        /// <summary>
        /// Main weather data
        /// </summary>
        [DataMember(Name = "main")] 
        public MainWeatherData MainWeatherData { get; private set; }

        /// <summary>
        /// Wind data
        /// </summary>
        [DataMember(Name = "wind")]
        public Wind Wind { get; private set; }

        /// <summary>
        /// Cloud data
        /// </summary>
        [DataMember(Name = "clouds")]
        public Clouds Clouds { get; private set; }

        /// <summary>
        /// System data
        /// </summary>
        [DataMember(Name = "sys")]
        public SystemData SystemData { get; private set; }

    }
}
