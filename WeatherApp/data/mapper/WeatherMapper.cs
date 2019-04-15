using System;
using WeatherApp.data.network.dto.response;
using WeatherApp.model;

namespace WeatherApp.data.mapper
{
    public class WeatherMapper
    {
        public WeatherEntity Map(CityWeatherItem cityWeatherItem)
        {
            WeatherEntity weatherEntity = new WeatherEntity
            {
                City = cityWeatherItem.name,
                Country = cityWeatherItem.sys.country,
                Temperature = cityWeatherItem.main.temp - 273.15
            };
            return weatherEntity;
        }
    }
}
