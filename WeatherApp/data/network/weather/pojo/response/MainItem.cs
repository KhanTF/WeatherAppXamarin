using System;
namespace WeatherApp.data.network.dto.response
{
    public class MainItem
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }
}
