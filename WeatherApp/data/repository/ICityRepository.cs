using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.ui.model;

namespace WeatherApp.data.db.repository
{
    public interface ICityRepository
    {
        Task<List<CityEntity>> GetCityList(string city); 
    }
}
