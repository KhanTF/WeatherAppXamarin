using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using WeatherApp.ui.model;

namespace WeatherApp.data.db.dao.impl
{
    public class CityDao : BaseDao<CityEntity>, ICityDao
    {

        public CityDao(ISqliteConnection sqlitePath) : base(sqlitePath) { }

        public Task<CityEntity> GetCity(int id)
        {
            return Task<CityEntity>.Factory.StartNew(() =>
            {
                List<CityEntity> queryResult = sqliteConnection.Connection.Query<CityEntity>("SELECT * FROM CityEntity WHERE Id="+id);
                if(queryResult.Count >0)
                {
                    return queryResult[0];
                }
                else
                {
                    return queryResult[0];
                }
            }); 
        }

        public Task<IList<CityEntity>> GetCityList()
        {
            return Task<IList<CityEntity>>.Factory.StartNew(() =>
            {
                List<CityEntity> queryResult = sqliteConnection.Connection.Query<CityEntity>("SELECT * FROM CityEntity");
                return queryResult;
            });
        }
    }
}
