using csWeatherAppNetCore.WeatherApiModel;
using System;

namespace csWeatherAppNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionDisplay currentConditionDisplay = new CurrentConditionDisplay(weatherData);
            weatherData.StartWeatherTracking(2);
        }
    }
}
