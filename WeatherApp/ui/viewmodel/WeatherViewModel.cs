using System;
using System.Collections.Generic;
using WeatherApp.data.repository;
using WeatherApp.model;
using Xamarin.Forms;

namespace WeatherApp.ui.viewmodel
{
    public class WeatherViewModel : BaseViewModel
    {

        private static readonly string KEY_CITY = "WeatherViewModel_City";
        private static readonly string KEY_TEMPERATURE = "WeatherViewModel_Temperature";
        private string city;
        private string temperature; 

        public string Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public void SetWeatherEntity(WeatherEntity weatherEntity)
        {
            this.City = weatherEntity.City;
            this.Temperature = weatherEntity.Temperature.ToString() + " C";
        }

        public WeatherViewModel(INavigation navigation) : base()
        { 
        }


        public void OnSaveState(IDictionary<string, object> state)
        {
            state[KEY_CITY] = City;
            state[KEY_TEMPERATURE] = Temperature;
        }
        public void OnRestoreState(IDictionary<string, object> state)
        {
            if (state.ContainsKey(KEY_CITY))
            {
                City = state[KEY_CITY] as string;
            }
            if (state.ContainsKey(KEY_TEMPERATURE))
            {
                Temperature = state[KEY_TEMPERATURE] as string;
            }
        }
    }
}
