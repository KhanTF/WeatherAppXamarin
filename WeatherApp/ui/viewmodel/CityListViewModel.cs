using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using WeatherApp.data.db.repository;
using WeatherApp.data.network.kladr;
using WeatherApp.data.network.kladr.pojo;
using WeatherApp.data.repository;
using WeatherApp.exception;
using WeatherApp.model;
using WeatherApp.ui.model;
using WeatherApp.ui.util.alert;
using WeatherApp.ui.view;
using Xamarin.Forms;

namespace WeatherApp.ui.viewmodel
{
    public class CityListViewModel : BaseViewModel
    {
        private static readonly string KEY_CITY_INPUT = "KEY_CITY_INPUT";
        private readonly INavigation navigation;
        private readonly ICityRepository cityRepository;
        private readonly IWeatherRepository weatherRepository;
        private readonly IAlertManager alertManager;
        private IList<CityEntity> cityModelList = new List<CityEntity>();
        private bool isProgressDialogVisible;
        private bool isProgressVisible;
        private bool isListVisible;
        private bool isRetryVisible;
        private bool isEmptyVisible;
        private string cityTextCurrent;
        private string cityInput;

        public string CityInput
        {
            get
            {
                return cityInput;
            }
            set
            {
                cityInput = value;
                OnPropertyChanged("CityInput");
            }
        }

        public CityListViewModel(ICityRepository cityRepository, IWeatherRepository weatherRepository, IAlertManager alertManager,INavigation navigation) : base()
        {
            this.alertManager = alertManager;
            this.navigation = navigation;
            this.cityRepository = cityRepository;
            this.weatherRepository = weatherRepository;
            IsEmptyVisible = CityModelList.Count == 0;
        }

        public bool IsProgressDialogVisible
        {
            get
            {
                return isProgressDialogVisible;
            }
            set
            {
                isProgressDialogVisible = value;
                OnPropertyChanged("IsProgressDialogVisible");
            }
        }

        public IList<CityEntity> CityModelList
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

        public bool IsListVisible
        {
            get { return isListVisible; }
            set
            {
                isListVisible = value;
                OnPropertyChanged("IsListVisible");
            }
        }

        public void OnSaveState(IDictionary<string,object> state)
        {
            state[KEY_CITY_INPUT] = cityTextCurrent;
        }
        public void OnRestoreState(IDictionary<string,object> state)
        {
            if (state.ContainsKey(KEY_CITY_INPUT))
            {
                CityInput = state[KEY_CITY_INPUT] as string;
            }
        }

        public async void OnCitySelected(CityEntity cityEntity)
        {
            IsProgressDialogVisible = true;
            try
            {
                WeatherEntity weatherEntity = await weatherRepository.GetWeather(cityEntity.Name); 
                await navigation.PushAsync(WeatherPage.GetInstance(weatherEntity));
            }
            catch (WeatherNotFoundException)
            {
                alertManager.ShowAlert("Город не найден", "Не удалось определить город", "Ок");
            }
            catch (Exception)
            {
                alertManager.ShowAlert("Ошибка", "Неизветная ошибка", "Ок");
            }
            finally
            {
                IsProgressDialogVisible = false;
            }
        }

        public void OnCityNameChanged(string city)
        { 
            LoadData(city.Trim());
        }

        public async void OnFindMe()
        {
            IsProgressDialogVisible = true;
            Position position = await CrossGeolocator.Current.GetPositionAsync();
            try
            {
                WeatherEntity weatherEntity = await weatherRepository.GetWeather(position.Latitude, position.Longitude); 
                await navigation.PushAsync(WeatherPage.GetInstance(weatherEntity));
            }
            catch (Exception)
            {
                alertManager.ShowAlert("Ошибка", "Неизвестная ошибка", "Ок");
            }
            IsProgressDialogVisible = false; 
        }

        private async void LoadData(string city)
        {
            cityTextCurrent = city;

            IsRetry = false;
            IsEmptyVisible = false;
            IsProgressVisible = true;
            IsListVisible = false;

            await Task.Delay(500);

            if (!city.Equals(cityTextCurrent))
            {
                return;
            }

            if (city == null || city.Equals(""))
            {
                CityModelList = new List<CityEntity>();
            }
            else
            {
                try
                {
                    CityModelList = await cityRepository.GetCityList(city);
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

    }
}
