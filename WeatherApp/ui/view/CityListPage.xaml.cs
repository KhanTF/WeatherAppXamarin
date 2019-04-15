using System;
using System.Collections.Generic;
using WeatherApp.di;
using WeatherApp.ui.model;
using WeatherApp.ui.util.state;
using WeatherApp.ui.viewmodel;
using Xamarin.Forms;

namespace WeatherApp.ui.view
{
    public partial class CityListPage : ContentPage, IMemento
    {

        private CityListViewModel cityListViewModel;
        public CityListViewModel CityListViewModel
        {
            get { return cityListViewModel; }
            set
            {
                cityListViewModel = value;
                BindingContext = value;
            }
        }

        public CityListPage()
        {
            Injector.GetInstance().Inject(this);
            InitializeComponent();  
        }

        public void OnCitySelected(object sender, ItemTappedEventArgs e)
        {
            CityEntity cityEntity = e.Item as CityEntity;
            CityListViewModel.OnCitySelected(cityEntity);
        }

        public void OnCityTextChanged(object sender, TextChangedEventArgs e)
        {
            CityListViewModel.OnCityNameChanged(e.NewTextValue);
        }

        void OnRetry(object sender, System.EventArgs e)
        {
            CityListViewModel.OnRetry();
        }

        void OnFindMe(object sender, System.EventArgs e)
        {
            CityListViewModel.OnFindMe();
        }

        public string GetId()
        {
            return "CityListPage";
        }

        public IDictionary<string, object> GetState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            CityListViewModel.OnSaveState(state);
            return state;
        }

        public void SetState(IDictionary<string, object> state)
        {
            CityListViewModel.OnRestoreState(state);
        }
    }
}
