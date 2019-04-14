using System;
using WeatherApp.data.db.dao;

namespace WeatherApp.data
{
    public class DataProvider
    {
       
        public SqliteConnectionProvider ProvideConnectionProvider()
        {
            return new SqliteConnectionProvider();
        }

        public DaoProvider ProvideDaoProvider()
        {
            return new DaoProvider(ProvideConnectionProvider());
        }

    }
}
