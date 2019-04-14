using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.data.db.dto;

namespace WeatherApp.data.db.dao.impl
{
    public class WeatherDao : BaseDao<WeatherEntity>,IWeatherDao
    {
        public WeatherDao(ISqliteConnection sqliteConnection) : base(sqliteConnection)
        {
        }

        public Task<IList<WeatherEntity>> GetWeatherByCityId(int cityId)
        {
            return Task<IList<WeatherEntity>>.Factory.StartNew(() =>
            {
                List<WeatherEntity> queryResult = sqliteConnection.Connection.Query<WeatherEntity>("SELECT * FROM WeatherEntity WHERE CityId=" + cityId);
                return queryResult;
            });
        }
    }
}
