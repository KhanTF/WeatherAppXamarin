using System;
using WeatherApp.data.network.kladr.pojo;
using WeatherApp.ui.model;

namespace WeatherApp.data.network.mapper
{
    public class CityMapper
    {
        public CityEntity Map(ResultSearchItem resultSearchItem)
        {
            CityEntity cityEntity = new CityEntity
            {
                Name = resultSearchItem.name
            };
            return cityEntity;
        }
    }
}
