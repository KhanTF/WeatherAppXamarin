using System;
using System.Collections.Generic;
using WeatherApp.ui.viewmodel;
using Xamarin.Forms;

namespace WeatherApp.ui.view
{
    public partial class CityListPage : ContentPage
    {

        private CityListViewModel cityListViewModel = new CityListViewModel();

        public CityListPage()
        {
            InitializeComponent();
            Title = "Список городов";
            BindingContext = cityListViewModel;
        }

        public void OnCitySelected(object sender, ItemTappedEventArgs e)
        { 
        }

        public void OnCityTextChanged(object sender, TextChangedEventArgs e)
        {
            cityListViewModel.OnCityNameChanged(e.NewTextValue);
        }

        void OnRetry(object sender, System.EventArgs e)
        {
            cityListViewModel.OnRetry();
        }

        void OnFindMe(object sender, System.EventArgs e)
        {
            cityListViewModel.OnFindMe();
        }
    }
}
