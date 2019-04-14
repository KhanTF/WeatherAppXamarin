using System;
using System.IO;
using WeatherApp.data.db;
using WeatherApp.Droid;

namespace WeatherApp.Droid
{
    public class SqlitePathAndroid : ISqlitePath
    {
        public string GetDatabasePath(string name)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, name);
            return path;
        }
    }
}
