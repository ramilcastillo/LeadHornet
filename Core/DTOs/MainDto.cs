using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class MainDto
    {
        public decimal temp { get; set; }
        public decimal feels_like { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
        public decimal pressure { get; set; }
        public decimal humidity { get; set; }
    }
}
