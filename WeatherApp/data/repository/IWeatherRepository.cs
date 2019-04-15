using System;
using System.Threading.Tasks;
using WeatherApp.model;

namespace WeatherApp.data.repository
{
    public interface IWeatherRepository
    {
        Task<WeatherEntity> GetWeather(string city);
        Task<WeatherEntity> GetWeather(double lat, double lon);
    }
}
