using Core.DTOs;

namespace Services.External.OpenWeatherAPI
{
    public interface IWeatherUpdate
    {
        WeatherForecastDto GetWeather(string latitude, string longitude);
        WeatherForecastDto GetWeatherByCityCountry(string city, string country);
    }
}
