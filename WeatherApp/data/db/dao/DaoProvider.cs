using System;
using WeatherApp.data.db.dao.impl;

namespace WeatherApp.data.db.dao
{
    public class DaoProvider
    {
 
        private ISqliteConnection sqliteConnection;
        private ICityDao cityDao;

        public string ProvideDbName()
        {
            return "weather.db";
        }

        private ISqliteConnection ProvideSqliteConnection(string name)
        {
#if __ANDROID__
            return new SqlitePathAndroid(name);
#elif __IOS__
            return new SqlitePathIos(name);
#else
            return null;
#endif
        }

        public ISqliteConnection ProvideSqliteConnection()
        {
            if (sqliteConnection == null)
            {
                ISqliteConnection sqlitePathLocal = ProvideSqliteConnection(ProvideDbName());
                sqliteConnection = sqlitePathLocal;
                return sqlitePathLocal;
            }
            else
            {
                return sqliteConnection;
            }
        }

        public ICityDao ProvideCityDao()
        {
            if (cityDao == null)
            {
                ICityDao instance =  new CityDao(ProvideSqliteConnection());
                cityDao = instance;
                return instance;
            }
            else
            {
                return cityDao;
            }
        }

    }
}
