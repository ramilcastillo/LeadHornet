using Core.DTOs;
using Newtonsoft.Json;
using RestSharp;

namespace Services.External.OpenWeatherAPI
{
    public class WeatherUpdate: IWeatherUpdate
    {
        private const string appId = "3899ed04c36e648fd32a45e5da491c37";
        //api.openweathermap.org/data/2.5/weather?lat=35&lon=139
        public WeatherForecastDto GetWeather(string latitude, string longitude)
        {
            try
            {
                var client = new RestClient("https://api.openweathermap.org");
                var request = new RestRequest("data/2.5/weather/", Method.GET);
                request.AddParameter("lat", latitude);
                request.AddParameter("lon", longitude);
                request.AddParameter("APPID", appId);
                var queryResult = client.Execute(request).Content;
                var weather = JsonConvert.DeserializeObject<WeatherForecastDto>(queryResult);
                return weather;
            }
            catch (System.Exception x)
            {
                throw new System.Exception(x.Message);
            }
        }

        public WeatherForecastDto GetWeatherByCityCountry(string city, string country)
        {
            try
            {
                var client = new RestClient("https://api.openweathermap.org");
                var request = new RestRequest("data/2.5/weather/", Method.GET);
                if (city != string.Empty && country != string.Empty)
                {
                    request.AddParameter("q", city + "," + country);
                }
                else if (city != string.Empty && country == string.Empty)
                {
                    request.AddParameter("q", city);
                }
                else { }

                request.AddParameter("APPID", appId);
                var queryResult = client.Execute(request).Content;
                var weather = JsonConvert.DeserializeObject<WeatherForecastDto>(queryResult);
                return weather;
            }
            catch (System.Exception x)
            {
                throw new System.Exception(x.Message);
            }
        }
    }
}
