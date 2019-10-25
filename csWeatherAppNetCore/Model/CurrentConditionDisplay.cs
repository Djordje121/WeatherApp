using csWeatherAppNetCore.Helpers;
using System;
using csWeatherAppNetCore.WeatherApiModel;
using csWeatherAppNetCore.Interfaces;
using csWeatherAppNetCore.Model;

namespace csWeatherAppNetCore
{
    class CurrentConditionDisplay : IObserver, IDisplay
    {
        private Observable _subject;
        private DateTime _dateCalculated;
        private DateTime _sunrise;
        private DateTime _sunset;

        private WeatherData _weatherData;

        public CurrentConditionDisplay(Observable subject)
        {
            _subject = subject;
            Subscribe();

        }
        public void Update(object sender, EventArgs args)
        {
            var wTracker = sender as WeatherDataTracker;
            _weatherData = wTracker?.wData;
            if (_weatherData != null)
            {
                _dateCalculated = UnixTimestampConverter.UnixTimestampToDateTime(_weatherData.DateCalculated);
                _sunrise = UnixTimestampConverter.UnixTimestampToDateTime(_weatherData.SystemData.Sunrise);
                _sunset = UnixTimestampConverter.UnixTimestampToDateTime(_weatherData.SystemData.Sunset);
                Display();
            }
        }

        public void Subscribe()
        {
            if (_subject != null)
            {
                _subject.NotifyObserversEventHandler+= Update;
            }
        }

        public void Unsubscribe()
        {
            if (_subject != null)
            {
                _subject.NotifyObserversEventHandler -= Update;
            }
        }

        // TODO: Find better solution for this display logic.
        public void Display()
        {        
            // Using pull method.
            Console.WriteLine($"Calculated: {_dateCalculated}");
            Console.WriteLine($"City: {_weatherData.CityName} Country {_weatherData.SystemData.Country}");
            foreach (Weather weather in _weatherData.WeatherList)
            {
                Console.WriteLine($"{weather.Title} - {weather.Description}");
            }
            Console.WriteLine($"Visibility: {_weatherData.Visibility}m - Cloudiness: {_weatherData.Clouds.Cloudiness}%");

            Console.WriteLine($"Temperature: {_weatherData.MainWeatherData.Temperature} Celsius");
            Console.WriteLine($"Pressure: {_weatherData.MainWeatherData.Pressure} hPA");
            Console.WriteLine($"Humidity: {_weatherData.MainWeatherData.Humidity}%");
            Console.WriteLine($"Min temp: {_weatherData.MainWeatherData.MinDailyTemperature} Celsius");
            Console.WriteLine($"Max temp: {_weatherData.MainWeatherData.MaxDailyTemperature} Celsius");
            Console.WriteLine($"Wind {_weatherData.Wind.Speed}m/s {_weatherData.Wind.Degree} Degrees");
            Console.WriteLine($"Sunrise: {_sunrise}");
            Console.WriteLine($"Sunset: {_sunset}");
            Console.WriteLine("\n.......................................................\n");
        }
    }
}
