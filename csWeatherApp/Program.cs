using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using csWeatherApp.Helpers;
using csWeatherApp.WeatherApiModel;
using System.Threading;

namespace csWeatherApp
{
    class Program
    {
        static void Main()
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionDisplay currentConditionDisplay = new CurrentConditionDisplay(weatherData);
            weatherData.StartWeatherTracking(2);
         
        
      
           
            Console.ReadLine();
        }
    }
}
