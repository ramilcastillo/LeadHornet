using Core.DTOs;
using Newtonsoft.Json;
using RestSharp;

namespace Services.External.GeoLocationAPI
{
    public class GeoLocation: IGeoLocation
    {
        private readonly string accessKey = "49566377e22c4fdeb355893dd138a2af";
        public LocationResponse GetLocation(string ipAddress)
        {
            var client = new RestClient("https://ipapi.co");
            var request = new RestRequest(ipAddress+"/json/" ,Method.GET);
            var queryResult = client.Execute(request).Content;
            var location = JsonConvert.DeserializeObject<LocationResponse>(queryResult); 
            return location;
        }
    }
}
