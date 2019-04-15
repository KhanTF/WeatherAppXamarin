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
        private string pressure;
        private string cloud;
        private string lat;
        private string lon;

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

        public string Pressure
        {
            get
            {
                return pressure;
            }
            set
            {
                pressure = value;
                OnPropertyChanged("Pressure");
            }
        }

        public string Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                OnPropertyChanged("Lat");
            }
        }

        public string Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                OnPropertyChanged("Lon");
            }
        }

        public string Cloud
        {
            get
            {
                return cloud;
            }
            set
            {
                cloud = value;
                OnPropertyChanged("Cloud");
            }
        }

        public void SetWeatherEntity(WeatherEntity weatherEntity)
        {
            this.City = weatherEntity.City;
            this.Temperature = weatherEntity.Temperature.ToString() + " C";
            this.Lat = weatherEntity.Lat.ToString("0.00");
            this.Lon = weatherEntity.Lon.ToString("0.00");
            this.Cloud = weatherEntity.Cloud.ToString("0.0") + "%";
            this.Pressure = weatherEntity.Preseure.ToString("0.00") + " hPa";
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
