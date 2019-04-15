using System;
using WeatherApp.data.network.dto.response;
using WeatherApp.model;

namespace WeatherApp.data.mapper
{
    public class WeatherMapper
    {
        public WeatherEntity Map(CityWeatherItem cityWeatherItem, string cityLocal)
        {
            WeatherEntity weatherEntity = new WeatherEntity
            {
                City = cityWeatherItem.name,
                Country = cityWeatherItem.sys.country,
                Temperature = cityWeatherItem.main.temp - 273.15,
                CityLocal = cityLocal,
                Dt = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Lat = cityWeatherItem.coord.lat,
                Lon = cityWeatherItem.coord.lon,
                Wind = cityWeatherItem.wind.speed,
                Preseure = cityWeatherItem.main.pressure,
                Cloud = cityWeatherItem.clouds.all
            };
            return weatherEntity;
        }
    }
}
