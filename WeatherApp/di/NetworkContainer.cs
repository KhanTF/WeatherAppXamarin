using System;
using System.Net.Http;
using WeatherApp.data.network;
using WeatherApp.data.network.kladr;

namespace WeatherApp.di
{
    public class NetworkContainer
    {
        private HttpClient httpClient;
        private KladrApi kladrApi;
        private WeatherApi weatherApi;

        public NetworkContainer()
        {
            httpClient = new HttpClient();
            kladrApi = new KladrApi(httpClient);
            weatherApi = new WeatherApi(httpClient);
        }

        public HttpClient ProvideHttpClient()
        {
            return httpClient;
        }

        public WeatherApi ProvideWeatherApi()
        {
            return weatherApi;
        }

        public KladrApi ProvideKladrApi()
        {
            return kladrApi;
        }

    }
}
