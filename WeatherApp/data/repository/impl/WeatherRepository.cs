using System;
using System.Threading.Tasks;
using WeatherApp.data.mapper;
using WeatherApp.data.network;
using WeatherApp.data.network.dto.response;
using WeatherApp.model;

namespace WeatherApp.data.repository.impl
{
    public class WeatherRepository : IWeatherRepository
    {

        private WeatherApi weatherApi;
        private WeatherMapper weatherMapper;

        public WeatherRepository(WeatherApi weatherApi, WeatherMapper weatherMapper)
        {
            this.weatherApi = weatherApi;
            this.weatherMapper = weatherMapper;
        }

        public async Task<WeatherEntity> GetWeather(string city)
        {
            CityWeatherItem cityWeatherItem = await weatherApi.GetWeatherByCity(city);
            return weatherMapper.Map(cityWeatherItem);
        }

        public async Task<WeatherEntity> GetWeather(double lat, double lon)
        {
            CityWeatherItem cityWeatherItem = await weatherApi.GetWeatherByCoord(lat,lon);
            return weatherMapper.Map(cityWeatherItem);
        }
    }
}
