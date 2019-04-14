using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using WeatherApp.data.network.kladr;
using WeatherApp.data.network.kladr.pojo;
using WeatherApp.ui.model;

namespace WeatherApp.ui.viewmodel
{
    public class CityListViewModel : BaseViewModel
    {

        private KladrApi kladrApi = new KladrApi(new HttpClient());
        private IList<CityModel> cityModelList = new List<CityModel>();
        private bool isProgressVisible;
        private bool isListVisible;
        private bool isRetryVisible;
        private bool isEmptyVisible;

        private string cityTextCurrent;

        public CityListViewModel()
        {
            IsEmptyVisible = CityModelList.Count == 0; 
        }

        public IList<CityModel> CityModelList
        {
            get { return cityModelList; }
            set
            {
                cityModelList = value;
                OnPropertyChanged("CityModelList");
            }
        }
        public bool IsEmptyVisible
        {
            get { return isEmptyVisible; }
            set
            {
                isEmptyVisible = value;
                OnPropertyChanged("IsEmptyVisible");
            }
        }
        public bool IsProgressVisible
        {
            get { return isProgressVisible; }
            set
            {
                isProgressVisible = value;
                OnPropertyChanged("IsProgressVisible");
            }
        }
        public bool IsRetry
        {
            get { return isRetryVisible; }
            set
            {
                isRetryVisible = value;
                OnPropertyChanged("IsRetry");
            }
        }

        public void onSaveState()
        {

        }

        public bool IsListVisible
        {
            get { return isListVisible; }
            set
            {
                isListVisible = value;
                OnPropertyChanged("IsListVisible");
            }
        }

        public void OnCityNameChanged(string city)
        {
            LoadData(city.Trim());
        }

        public async void OnFindMe()
        {
            Position position = await CrossGeolocator.Current.GetPositionAsync();
            Console.Write("Lat=" + position.Latitude.ToString() + ", Lon=" + position.Longitude.ToString());
        }

        private async void LoadData(string city)
        {
            cityTextCurrent = city;

            IsRetry = false;
            IsEmptyVisible = false;
            IsProgressVisible = true;
            IsListVisible = false;

            await Task.Factory.StartNew(() =>
            {
                Thread.Sleep(500);
            });

            if (!city.Equals(cityTextCurrent))
            {
                return;
            }

            if (city == null || city.Equals(""))
            {
                CityModelList = new List<CityModel>();
            }
            else
            { 
                try
                { 
                    CityModelList = await GetLoadCity(city);
                }
                catch (Exception)
                {
                    IsRetry = true;
                    IsProgressVisible = false;
                    IsListVisible = false;
                    IsEmptyVisible = false;
                    return;
                }
            }

            IsRetry = false;
            IsProgressVisible = false;
            IsListVisible = true;
            IsEmptyVisible = CityModelList.Count == 0;
        }

        public void OnRetry()
        { 
            LoadData(cityTextCurrent);
        }

        private async Task<List<CityModel>> GetLoadCity(string city)
        {
            List<CityModel> cityModels = new List<CityModel>();
            if (city.Length > 0)
            {
                List<ResultSearchItem> cities = await kladrApi.GetSearchCity(city);
                foreach (ResultSearchItem resultSearch in cities)
                {
                    cityModels.Add(new CityModel(resultSearch.id, resultSearch.name));
                }
            }
            return cityModels;
        }

    }
}
