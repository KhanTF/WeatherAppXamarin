using System;
namespace WeatherApp.data.network.kladr.pojo
{
    public class ResultSearchItem : IEquatable<ResultSearchItem>
    {
        public long id { get; set; }
        public string name { get; set; }

        public bool Equals(ResultSearchItem other)
        {
            if (other == null) return false;
            if (name == null)
            {
                return other.name == null;
            }
            return name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            if (name == null) return 0;
            return name.GetHashCode();
        }
    }
}
