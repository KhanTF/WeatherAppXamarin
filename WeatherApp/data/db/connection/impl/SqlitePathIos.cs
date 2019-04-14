using System;
using System.IO;

namespace WeatherApp.data.db
{
    public class SqlitePathIos : ISqliteConnection
    {

        public SqlitePathIos(string name) : base(name)
        {

        }

        public override string GetDatabasePath(string name)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, name);
            return path;
        }
    }
}
