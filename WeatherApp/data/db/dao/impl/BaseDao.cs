using System;
using SQLite;

namespace WeatherApp.data.db.dao
{
    public class BaseDao<T>
    {

        protected ISqliteConnection sqliteConnection;

        public BaseDao(ISqliteConnection sqlitePath)
        {
            sqlitePath.Connection.CreateTable<T>();
            this.sqliteConnection = sqlitePath;
        }


    }
}
