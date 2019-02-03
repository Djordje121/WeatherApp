using csWeatherApp.Helpers;
using System;
using csWeatherApp.WeatherApiModel;

namespace csWeatherApp
{
    class CurrentConditionDisplay : IObserver
    {
        private Observable _subject;

        private DateTime _dateCalculated;
        private DateTime _sunrise;
        private DateTime _sunset;

        public CurrentConditionDisplay(Observable subject)
        {
            _subject = subject;
            Subscribe();

        }
        public void Update(object sender, EventArgs e)
        {
            // using pull model
            WeatherData weatherData = sender as WeatherData;
            if (weatherData != null)
            {
                _dateCalculated = UnixTimestampConverter.UnixTimestampToDateTime(weatherData.DateCalculated);
                _sunrise = UnixTimestampConverter.UnixTimestampToDateTime(weatherData.SystemData.Sunrise);
                _sunset = UnixTimestampConverter.UnixTimestampToDateTime(weatherData.SystemData.Sunset);
                Console.WriteLine($"Calculated: {_dateCalculated}");
                Console.WriteLine($"City: {weatherData.CityName} Country {weatherData.SystemData.Country}");
                foreach (Weather weather in weatherData.WeatherList)
                {
                    Console.WriteLine($"{weather.Title} - {weather.Description}");
                }
                Console.WriteLine($"Visibility: {weatherData.Visibility}m - Cloudiness: {weatherData.Clouds.Cloudiness}%");

                Console.WriteLine($"Temperature: {weatherData.MainWeatherData.Temperature} Celsius");
                Console.WriteLine($"Pressure: {weatherData.MainWeatherData.Pressure} hPA");
                Console.WriteLine($"Humidity: {weatherData.MainWeatherData.Humidity}%");
                Console.WriteLine($"Min temp: {weatherData.MainWeatherData.MinDailyTemperature} Celsius");
                Console.WriteLine($"Max temp: {weatherData.MainWeatherData.MaxDailyTemperature} Celsius");
                Console.WriteLine($"Wind {weatherData.Wind.Speed}m/s {weatherData.Wind.Degree} Degrees");
                Console.WriteLine($"Sunrise: {_sunrise}");
                Console.WriteLine($"Sunset: {_sunset}");
                Console.WriteLine("\n.......................................................\n");
            }
        }

        public void Subscribe()
        {
            if (_subject != null)
                _subject.AddObserver(this);
        }

        public void Unsubscribe()
        {
            if (_subject != null)
                _subject.RemoveObserver(this);
        }       
    }
}
