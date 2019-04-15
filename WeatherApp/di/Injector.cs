using System;
using WeatherApp.ui;
using WeatherApp.ui.view;

namespace WeatherApp.di
{
    public class Injector
    {
        private static Injector container;
        public static Injector GetInstance()
        {
            if (container == null)
            {
                lock (typeof(Injector))
                {
                    if(container == null)
                    {
                        container = new Injector();
                    }
                    return container;
                } 
            }
            else
            {
                return container;
            } 
        }

        private readonly RepositoryContainer repositoryContainer;
        private readonly NetworkContainer networkContainer;
        private readonly ViewModelContainer viewModelContainer;

        public Injector()
        {
            networkContainer = new NetworkContainer();
            repositoryContainer = new RepositoryContainer(networkContainer);
            viewModelContainer = new ViewModelContainer(repositoryContainer);
        }

        public void Inject(CityListPage cityListPage)
        {
            cityListPage.CityListViewModel = viewModelContainer.ProvideCityViewModel(cityListPage);
        }
        public void Inject(MainPage mainPage)
        {

        }
        public void Inject(WeatherPage weatherPage)
        {
            weatherPage.WeatherViewModel = viewModelContainer.ProvideWeatherViewModel(weatherPage);
        }
    }
}
