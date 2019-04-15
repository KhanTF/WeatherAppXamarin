using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.data.db.dao;
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
        private IWeatherDao weatherDao;

        public WeatherRepository(WeatherApi weatherApi, IWeatherDao weatherDao, WeatherMapper weatherMapper)
        {
            this.weatherApi = weatherApi;
            this.weatherMapper = weatherMapper;
            this.weatherDao = weatherDao;
        }

        private bool IsExpired(long dt)
        {
            return Math.Abs(DateTimeOffset.Now.ToUnixTimeMilliseconds() - dt) > 10* 60 * 1000;
        }

        public async Task<WeatherEntity> GetWeather(string city)
        {
            IList<WeatherEntity> weatherEntityList = await weatherDao.GetWeatherByCity(city);
            if (weatherEntityList.Count == 0 || IsExpired(weatherEntityList[0].Dt))
            {
                CityWeatherItem cityWeatherItem = await weatherApi.GetWeatherByCity(city);
                WeatherEntity weatherEntity =  weatherMapper.Map(cityWeatherItem, city);
                await weatherDao.InsertOrUpdate(weatherEntity);
                return weatherEntity;
            }
            else
            {
                return weatherEntityList[0];
            }
        }

        public async Task<WeatherEntity> GetWeather(double lat, double lon)
        {
            IList<WeatherEntity> weatherEntityList = await weatherDao.GetWeatherByCoord(lat,lon);
            if (weatherEntityList.Count == 0 || IsExpired(weatherEntityList[0].Dt))
            {
                CityWeatherItem cityWeatherItem = await weatherApi.GetWeatherByCoord(lat, lon);
                return weatherMapper.Map(cityWeatherItem, "");
            }
            else
            {
                return weatherEntityList[0];
            }
        }
    }
}
