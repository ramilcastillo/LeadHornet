using System.Collections.Generic;

namespace Core.DTOs
{
    public class WeatherForecastDto
    {
        public IEnumerable<WeatherDto> weather { get; set; }
        public WindDto wind { get; set; }
        public SysDto sys { get; set; }
        public MainDto main { get; set; }
    }
}
