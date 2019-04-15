using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.data.network.dto.response;
using WeatherApp.exception;
using WeatherApp.model;

namespace WeatherApp.data.network
{
    public class WeatherApi
    {

        private static readonly string APP_ID = "199e51a7251d81ae172475ea5b313f94";
        private static readonly string BASE_URL = "http://api.openweathermap.org/data/2.5/";
        private readonly HttpClientWrapper httpClientWrapper;

        public WeatherApi(HttpClient httpClient)
        {
            this.httpClientWrapper = new HttpClientWrapper(httpClient, BASE_URL);
        }

        private async Task<CityWeatherItem> GetWeather(IDictionary<string, string> param)
        {
            HttpResponseMessage httpResponseMessage = await httpClientWrapper.Get("weather", param);
            HttpStatusCode code = httpResponseMessage.StatusCode;

            if (code == HttpStatusCode.OK)
            {
                HttpContent httpContent = httpResponseMessage.Content;
                string json = await httpContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CityWeatherItem>(json);
            }
            else
            {
                if (code == HttpStatusCode.NotFound)
                    throw new WeatherNotFoundException("Weather is null for "+httpResponseMessage.RequestMessage.RequestUri.AbsolutePath);
                else
                    throw new Exception("Get weather by city exception");
            }
        }

        public async Task<CityWeatherItem> GetWeatherByCity(string city)
        {
            IDictionary<string, string> param = new Dictionary<string, string>
            {
                ["appid"] = APP_ID,
                ["q"] = city
            };
            return await GetWeather(param);
        }
        public async Task<CityWeatherItem> GetWeatherByCoord(double lat, double lon)
        {
            IDictionary<string, string> param = new Dictionary<string, string>
            {
                ["appid"] = APP_ID,
                ["lat"] = lat.ToString("0.######"),
                ["lon"] = lon.ToString("0.######")
            };
            return await GetWeather(param);
        }

    }
}
