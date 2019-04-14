using System;
namespace WeatherApp.ui.model
{
    public class CityEntity
    {
        private long id;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public CityEntity(long id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
