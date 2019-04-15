using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.model;

namespace WeatherApp.data.db.dao
{
    public interface IWeatherDao
    {
        Task<IList<WeatherEntity>> GetWeatherByCity(string city);
        Task<IList<WeatherEntity>> GetWeatherByCoord(double lat , double lon);
        Task InsertOrUpdate(WeatherEntity weatherEntity);
    }
}
