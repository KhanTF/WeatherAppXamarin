using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.model;

namespace WeatherApp.data.db.dao.impl
{
    public class WeatherDao : BaseDao<WeatherEntity>, IWeatherDao
    {
        public WeatherDao(ISqliteConnection sqliteConnection) : base(sqliteConnection) { }

        public Task<IList<WeatherEntity>> GetWeatherByCity(string city)
        {
            return Task<IList<WeatherEntity>>.Factory.StartNew(() =>
            {
                List<WeatherEntity> queryResult = sqliteConnection.Connection.Query<WeatherEntity>("SELECT * FROM WeatherEntity WHERE CityLocal='" + city + "' OR City='"+city+"' Limit 1");
                return queryResult;
            });
        }

        public Task<IList<WeatherEntity>> GetWeatherByCoord(double lat, double lon)
        {
            return Task<IList<WeatherEntity>>.Factory.StartNew(() => {
                string lowLat = (lat - 0.2).ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture);
                string highLat = (lat + 0.2).ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture); ;
                string lowLon = (lon - 0.2).ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture); ;
                string highLon = (lon + 0.2).ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture); ;
                List<WeatherEntity> queryResult = sqliteConnection.Connection.Query<WeatherEntity>("SELECT * FROM WeatherEntity WHERE Lat >= "+lowLat+ " AND Lat <= " + highLat +" AND Lon >= "+lowLon+" AND Lon <= "+highLon+" Limit 1");
                return queryResult;
            });
        }

        public Task InsertOrUpdate(WeatherEntity weatherEntity)
        {
            return Task.Factory.StartNew(() =>
            {
                sqliteConnection.Connection.BeginTransaction();
                sqliteConnection.Connection.InsertOrReplace(weatherEntity);
                sqliteConnection.Connection.Commit(); 
            });
        }
    }
}
