using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.External.GeoLocationAPI;
using Services.External.OpenWeatherAPI;

namespace LeadHornet.Web.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationApiController : ControllerBase
    {
        public string IPAddress { get; set; }
        public LocationResponse currentUserLocationInfo { get; set; }
        private readonly IGeoLocation _geoServices;
        private readonly IWeatherUpdate _weatherUpdate;

        public LocationApiController(IGeoLocation geoServices, IWeatherUpdate weatherUpdate)
        {
            _geoServices = geoServices;
            _weatherUpdate = weatherUpdate;
        }

        [HttpGet]
        public LocationResponse GetPublicIP()
        {
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            IPAddress = externalip.Replace("\n", "");
            var location =  _geoServices.GetLocation(IPAddress);
            currentUserLocationInfo = location;
            return location;
        }

        [HttpGet("{site?}")]
        public WeatherForecastDto GetWeather(string site)
        {
            try
            {
                string externalip = new WebClient().DownloadString("http://icanhazip.com");
                IPAddress = externalip.Replace("\n", "");
                var location = _geoServices.GetLocation(IPAddress);
                currentUserLocationInfo = location;
                var weather = _weatherUpdate.GetWeather(currentUserLocationInfo.latitude, currentUserLocationInfo.longitude);

                var inputLocation = site.Split(",");
                if (inputLocation.Length == 1)
                {
                    var city = inputLocation[0] == null ? "" : inputLocation[0].Trim();

                    var inputWeatherResponse = _weatherUpdate.GetWeatherByCityCountry(city, "");
                    weather.main = inputWeatherResponse.main;
                }
                else if (inputLocation.Length == 2)
                {
                    var city = inputLocation[0] == null ? "" : inputLocation[0].Trim();
                    var country = string.IsNullOrEmpty(inputLocation[1]) ? "" : inputLocation[1].Trim();
                    var inputWeatherResponse = _weatherUpdate.GetWeatherByCityCountry(city, country);
                    weather.main = inputWeatherResponse.main;
                }
                else
                {}

                return weather;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        } 
    }
}