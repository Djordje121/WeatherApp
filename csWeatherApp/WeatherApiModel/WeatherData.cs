using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;
using System.IO;
using csWeatherApp.Helpers;
using System.Threading;
using System.Configuration;
using csWeatherApp.Interfaces;

namespace csWeatherApp.WeatherApiModel
{
    /// <summary>
    ///  Used for storing web api weather response
    ///  TODO: add weather tracking impelmentation in different thread
    /// </summary>
    [DataContract]
    class WeatherData : Observable
    {
        private bool initilized = true;
        private const int milisecPerMin = 60000;
        private string request = "";

        public WeatherData()
        {
            initilized = true;
        }
        /// <summary>
        /// City id
        /// </summary>
        [DataMember(Name = "id")]
        public double CityId { get; private set; }

        /// <summary>
        /// City id
        /// </summary>
        [DataMember(Name = "name")]
        public string CityName { get; private set; }

        /// <summary>
        /// Visibility in meters 
        /// </summary>
        [DataMember(Name = "visibility")]
        public double Visibility { get; private set; }

        /// <summary>
        /// Internal server parameter
        /// </summary>
        [DataMember(Name = "cod")]
        public string Cod { get; private set; }

        /// <summary>
        /// Datetime of response calculation
        /// </summary>
        [DataMember(Name = "dt")]
        public double DateCalculated { get; private set; }

        /// <summary>
        /// City coordinates
        /// </summary>
        [DataMember(Name = "coord")]
        public Coordinates Coordinates { get; private set; }

        /// <summary>
        /// Weather condtion data
        /// </summary>
        [DataMember(Name = "weather")]
        public List<Weather> WeatherList { get; private set; }

        /// <summary>
        /// Main weather data
        /// </summary>
        [DataMember(Name = "main")] 
        public MainWeatherData MainWeatherData { get; private set; }

        /// <summary>
        /// Wind data
        /// </summary>
        [DataMember(Name = "wind")]
        public Wind Wind { get; private set; }

        /// <summary>
        /// Cloud data
        /// </summary>
        [DataMember(Name = "clouds")]
        public Clouds Clouds { get; private set; }

        /// <summary>
        /// System data
        /// </summary>
        [DataMember(Name = "sys")]
        public SystemData SystemData { get; private set; }

        private void MesurmentsChanged()
        {
            SetStateChanged();
            NotifyObservers();
        }

        private void FillObject(WeatherData data)
        {
            CityId = data.CityId;
            CityName = data.CityName;
            Visibility = data.Visibility;
            Cod = data.Cod;
            DateCalculated = data.DateCalculated;
            Coordinates = data.Coordinates;
            WeatherList = data.WeatherList;
            MainWeatherData = data.MainWeatherData;
            Wind = data.Wind;
            Clouds = data.Clouds;
            SystemData = data.SystemData;

        }

        public void CheckWeatherMesurments()
        {
            string requestUrl = "https://api.openweathermap.org/data/2.5/weather?id=3194360&units=metric&appid=803c3618a46f951af1c34f1662e3939c";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", "3194360");
            parameters.Add("units", "metric");
            parameters.Add("appid", "803c3618a46f951af1c34f1662e3939c");
       
            string json = HttpRequestHelper.GetApiRequest(requestUrl, parameters);
            WeatherData response = JsonConverter.DeserilizeObject<WeatherData>(json);
      
           
            if(response != null)
            {
                if(initilized)
                {
                    FillObject(response);
                    initilized = false;
                    MesurmentsChanged();
                }
                else if(response.DateCalculated > this.DateCalculated)
                {
                    FillObject(response);
                    MesurmentsChanged();
                }        
            }
        }

        public void StartWeatherTracking(int minutes)
        {
            while(true)
            {
                CheckWeatherMesurments();
                Thread.Sleep(milisecPerMin * minutes); 
            }
        }  
    }
}
