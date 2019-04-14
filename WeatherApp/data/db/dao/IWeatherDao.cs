using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.data.db.dto;

namespace WeatherApp.data.db.dao
{
    public interface IWeatherDao
    {
        Task<IList<WeatherEntity>> GetWeatherByCityId(int cityId);
    }
}
