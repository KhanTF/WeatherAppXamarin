using System;
using WeatherApp.ui;
using WeatherApp.ui.util.alert;
using WeatherApp.ui.view;
using WeatherApp.ui.viewmodel;
using Xamarin.Forms;

namespace WeatherApp.di
{
    public class ViewModelContainer
    {
        private RepositoryContainer repositoryContainer;

        public ViewModelContainer(RepositoryContainer repositoryContainer)
        {
            this.repositoryContainer = repositoryContainer;
        }

        public CityListViewModel ProvideCityViewModel(CityListPage cityListPage)
        {
            return new CityListViewModel(repositoryContainer.ProvideCityRepository(), repositoryContainer.ProvideWeatherRepository(), ProvideAlertManager(cityListPage),cityListPage.Navigation);
        }
        public WeatherViewModel ProvideWeatherViewModel(WeatherPage weatherPage)
        {
            return new WeatherViewModel(weatherPage.Navigation);
        }
        public IAlertManager ProvideAlertManager(Page page)
        {
            return new AlertManager(page);
        }

    }
}
