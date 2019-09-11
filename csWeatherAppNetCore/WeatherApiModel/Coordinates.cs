using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace csWeatherAppNetCore.WeatherApiModel
{
    [DataContract]
    class Coordinates
    {
        [DataMember(Name = "lat")]
        public double Latitude { get; private set; }

        [DataMember(Name = "lon")]
        public double Longitude { get; private set; }
       
    }
}
