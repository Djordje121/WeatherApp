using csWeatherAppNetCore.WeatherApiModel;
using csWeatherAppNetCore.Model;
using System;

namespace csWeatherAppNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherDataTracker = new WeatherDataTracker();
            var currentConditionDisplay = new CurrentConditionDisplay(weatherDataTracker);
            weatherDataTracker.StartWeatherTracking(2);
        }
    }
}
