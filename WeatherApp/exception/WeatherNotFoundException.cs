using System;
using System.Runtime.Serialization;

namespace WeatherApp.exception
{
    public class WeatherNotFoundException : Exception
    {
        public WeatherNotFoundException()
        {
        }

        public WeatherNotFoundException(string message) : base(message)
        {
        }

        public WeatherNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WeatherNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
