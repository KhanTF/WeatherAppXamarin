using System;
using System.IO;
using WeatherApp.data.db;
using WeatherApp.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SqlitePathIos))]
namespace WeatherApp.iOS
{
    public class SqlitePathIos : ISqlitePath
    {
        public string GetDatabasePath(string name)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); 
            var path = Path.Combine(libraryPath, name);
            return path;
        }
    }
}
