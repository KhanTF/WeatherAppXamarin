using System;
using System.Collections.Generic; 
using WeatherApp.ui.model;

namespace WeatherApp.data.db.repository
{
    public interface ICityRepository
    {
        List<CityEntity> GetCityList();
        
    }
}
