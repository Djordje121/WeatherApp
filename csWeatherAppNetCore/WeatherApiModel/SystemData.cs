using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherAppNetCore.WeatherApiModel
{
    [DataContract]
    class SystemData
    {
        /// <summary>
        /// Server internal parameter
        /// </summary>
        [DataMember(Name = "id")]
        public double Id { get; private set; }

        /// <summary>
        /// Server internal parameter
        /// </summary>
        [DataMember(Name = "type")]
        public int type { get; private set; }

        /// <summary>
        /// Server internal parameter
        /// </summary>
        [DataMember(Name = "message")]
        public double Message { get; private set; }

        /// <summary>
        /// Country code data
        /// <see cref="https://en.wikipedia.org/wiki/Lists_of_country_codes"/>
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; private set; }
        
        /// <summary>
        /// Sunrise in unix timestamp
        /// </summary>
        [DataMember(Name = "sunrise")]
        public double Sunrise { get; private set; }

        /// <summary>
        /// Sunset in unix timestamp
        /// </summary>
        [DataMember(Name = "sunset")]
        public double Sunset { get; private set; }
    }
}
