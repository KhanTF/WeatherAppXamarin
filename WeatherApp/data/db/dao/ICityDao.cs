using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.data.db.dto;
using WeatherApp.ui.model;

namespace WeatherApp.data.db.dao
{
    public interface ICityDao
    {
        Task<CityEntity> GetCity(int id);
        Task<IList<CityEntity>> GetCityList();
    }
}
