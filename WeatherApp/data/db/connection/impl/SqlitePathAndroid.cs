using System;
using System.IO;

namespace WeatherApp.data.db
{
    public class SqlitePathAndroid : ISqliteConnection
    {

        public SqlitePathAndroid(string name) : base(name)
        {

        }

        public override string GetDatabasePath(string name)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, name);
            return path;
        }

    }
}
