using Core.DTOs;

namespace Services.External.GeoLocationAPI
{
    public interface IGeoLocation
    {
        LocationResponse GetLocation(string ipAddress);
    }
}
