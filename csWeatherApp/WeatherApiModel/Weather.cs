using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherApp.WeatherApiModel
{
    /// <summary>
    ///  Stores weather condition description
    ///  <see cref="https://openweathermap.org/weather-conditions"/>
    /// </summary>
    [DataContract]
    class Weather
    {
        /// <summary>
        /// Weather condition id
        /// </summary>
        [DataMember(Name = "id")]
        public double Id { get; private set; }
        
        /// <summary>
        /// Weather condition
        /// </summary>
        [DataMember(Name = "main")]
        public string Title { get; private set; }

        /// <summary>
        /// Weather condition description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; private set; }

        /// <summary>
        ///  Weather icon id
        /// </summary>
        [DataMember(Name = "icon")]
        public string IconId { get; private set; }
    }
}
