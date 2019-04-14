using System;
using SQLite;

namespace WeatherApp.data.db
{
    public abstract class ISqliteConnection
    {
        public abstract string GetDatabasePath(string name);
        private SQLiteConnection connection;
        private bool isConnect;
        public readonly string name;

        public bool IsConnect
        {
            get { return isConnect; } 
        }

        public SQLiteConnection Connection
        {
            get
            {
                if (connection == null || !isConnect)
                {
                    isConnect = true;
                    connection = new SQLiteConnection(GetDatabasePath(name));
                }
                return connection;
            } 
        }

        protected ISqliteConnection(string name) => this.name = name;

        public void Close()
        {
            if (connection != null && isConnect)
            {
                connection.Close();
                connection = null;
                isConnect = false;
            }
        }

    }
}
