using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.data.network.dto.response;
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

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent httpContent = httpResponseMessage.Content;
                string json = await httpContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CityWeatherItem>(json);
            }
            else
            {
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
                ["lat"] = lat.ToString(),
                ["lon"] = lon.ToString()
            };
            return await GetWeather(param);
        }

    }
}
