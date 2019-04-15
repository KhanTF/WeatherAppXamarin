using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.data.db.repository;
using WeatherApp.data.network.kladr;
using WeatherApp.data.network.kladr.pojo;
using WeatherApp.data.network.mapper;
using WeatherApp.ui.model;

namespace WeatherApp.data.repository.impl
{
    public class CityRepository : ICityRepository
    {
        private KladrApi kladrApi;
        private CityMapper cityMapper;

        public CityRepository(KladrApi kladrApi, CityMapper cityMapper)
        {
            this.kladrApi = kladrApi;
            this.cityMapper = cityMapper;
        } 

        public async Task<List<CityEntity>> GetCityList(string city)
        {
            List<ResultSearchItem> resultSearchItems = await kladrApi.GetSearchCity(city); 
            return await Map(resultSearchItems.Distinct());
        }

        private Task<List<CityEntity>> Map(IEnumerable<ResultSearchItem> resultSearchItems)
        {
            return Task<List<CityEntity>>.Factory.StartNew(() =>
            {
                List<CityEntity> cityEntities = new List<CityEntity>();

                foreach (ResultSearchItem resultSearchItem in resultSearchItems)
                {
                    cityEntities.Add(cityMapper.Map(resultSearchItem));
                }
                return cityEntities;
            });
        }
    }
}
