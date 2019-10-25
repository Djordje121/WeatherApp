using System;
using System.Collections.Generic;
using System.Threading;
using csWeatherAppNetCore.Helpers;
using csWeatherAppNetCore.Interfaces;
using csWeatherAppNetCore.WeatherApiModel;

namespace csWeatherAppNetCore.Model
{
    class WeatherDataTracker : Observable
    {
        private bool _initilized = true;
        private const int _milisecPerMin = 60000;
        private string _request = "";

        public WeatherData wData { get; set; }

        public WeatherDataTracker()
        {
            _initilized = true;
        }

        public void StartWeatherTracking(int minutes)
        {
            while (true)
            {
                CheckWeatherMesurments();
                Thread.Sleep(_milisecPerMin * minutes);
            }
        }

        public void CheckWeatherMesurments()
        {
            var requestUrl = "https://api.openweathermap.org/data/2.5/weather?id=3194360&units=metric&appid=803c3618a46f951af1c34f1662e3939c";
            var parameters = new Dictionary<string, string>();
            parameters.Add("id", "3194360");
            parameters.Add("units", "metric");
            parameters.Add("appid", "803c3618a46f951af1c34f1662e3939c");

            string json = HttpRequestHelper.GetApiRequest(requestUrl, parameters);
            var response = JsonConverter.DeserilizeObject<WeatherData>(json);


            if (response != null)
            {
                if (_initilized)
                {
                    //FillObject(response);
                    wData = response;
                    _initilized = false;
                    MesurmentsChanged();
                }
                else if (response.DateCalculated > wData.DateCalculated)
                {
                    // FillObject(response);
                    wData = response;
                    MesurmentsChanged();
                }
            }
        }

        private void MesurmentsChanged()
        {
            SetStateChanged();
            NotifyObservers(this.wData);
        }

    }
}