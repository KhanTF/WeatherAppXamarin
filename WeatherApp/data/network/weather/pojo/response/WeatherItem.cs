using System;
namespace WeatherApp.data.network.dto.response
{
    public class WeatherItem
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
