using csWeatherAppNetCore.WeatherApiModel;
using csWeatherAppNetCore.Model;
using System;

namespace csWeatherAppNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataTracker weatherDataTracker = new WeatherDataTracker();
            CurrentConditionDisplay currentConditionDisplay = new CurrentConditionDisplay(weatherDataTracker);
            weatherDataTracker.StartWeatherTracking(2);
        }
    }
}
