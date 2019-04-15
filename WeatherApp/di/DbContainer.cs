using System;
using WeatherApp.data.db;
using WeatherApp.data.db.dao;
using WeatherApp.data.db.dao.impl;
using Xamarin.Forms;

namespace WeatherApp.di
{
    public class DbContainer
    {

        private readonly ISqliteConnection connection;
        private readonly IWeatherDao weatherDao;

        public DbContainer()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    connection = new SqlitePathAndroid("data.db");
                    break;
                case Device.iOS:
                    connection = new SqlitePathIos("data.db");
                    break;
            }
            weatherDao = new WeatherDao(connection);
        }

        public IWeatherDao ProvideWeatherDao()
        {
            return weatherDao;
        }

        public ISqliteConnection ProvideSqliteConnection()
        {
            return connection;
        }

    }
}
