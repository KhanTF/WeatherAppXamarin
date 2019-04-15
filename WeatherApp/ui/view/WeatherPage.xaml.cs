using System;
using System.Collections.Generic;
using WeatherApp.di;
using WeatherApp.model;
using WeatherApp.ui.util.state;
using WeatherApp.ui.viewmodel;
using Xamarin.Forms;

namespace WeatherApp.ui.view
{
    public partial class WeatherPage : ContentPage, IMemento
    {

        public static WeatherPage GetInstance(WeatherEntity weatherEntity)
        {
            WeatherPage weatherPage = new WeatherPage();  
            weatherPage.WeatherViewModel.SetWeatherEntity(weatherEntity);
            return weatherPage;
        }
 
        public string GetId()
        {
            return "WeatherPage";
        }

        public IDictionary<string, object> GetState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            weatherViewModel.OnSaveState(state);
            return state;
        }

        public void SetState(IDictionary<string, object> state)
        {
            weatherViewModel.OnRestoreState(state);
        }

        private WeatherViewModel weatherViewModel;
        public WeatherViewModel WeatherViewModel
        {
            get { return weatherViewModel; }
            set
            {
                weatherViewModel = value;
                BindingContext = value;
            }
        }

        public WeatherPage()
        { 
            InitializeComponent();
            Injector.GetInstance().Inject(this);
        }
    }
}
