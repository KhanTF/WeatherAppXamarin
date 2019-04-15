using System;
using System.Net.Http;
using WeatherApp.data.db.repository;
using WeatherApp.data.mapper;
using WeatherApp.data.network.mapper;
using WeatherApp.data.repository;
using WeatherApp.data.repository.impl;

namespace WeatherApp.di
{
    public class RepositoryContainer
    {

        private readonly ICityRepository cityRepository;
        private readonly IWeatherRepository weatherRepository;

        private readonly CityMapper cityMapper = new CityMapper();
        private readonly WeatherMapper weatherMapper = new WeatherMapper();

        public RepositoryContainer(NetworkContainer networkContainer)
        {
            cityRepository = new CityRepository(networkContainer.ProvideKladrApi(), cityMapper);
            weatherRepository = new WeatherRepository(networkContainer.ProvideWeatherApi(), weatherMapper);
        }

        public IWeatherRepository ProvideWeatherRepository()
        {
            return weatherRepository;
        }

        public ICityRepository ProvideCityRepository()
        {
            return cityRepository;
        }

    }
}
