using System;
using System.Collections.Generic;

namespace WeatherApp.data.network.dto.response
{
    public class CityWeatherItem
    {
        public CoordItem coord { get; set; }
        public List<WeatherItem> weather { get; set; }
        public string @base { get; set; }
        public MainItem main { get; set; }
        public int visibility { get; set; }
        public WindItem wind { get; set; }
        public CloudsItem clouds { get; set; }
        public int dt { get; set; }
        public SysItem sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
