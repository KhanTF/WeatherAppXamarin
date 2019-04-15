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
        private readonly DbContainer dbContainer;

        public Injector()
        {
            networkContainer = new NetworkContainer();
            dbContainer = new DbContainer();
            repositoryContainer = new RepositoryContainer(networkContainer, dbContainer);
            viewModelContainer = new ViewModelContainer(repositoryContainer); 
        }

        public void Inject(CityListPage cityListPage)
        {
            cityListPage.CityListViewModel = viewModelContainer.ProvideCityViewModel(cityListPage);
        } 
        public void Inject(WeatherPage weatherPage)
        {
            weatherPage.WeatherViewModel = viewModelContainer.ProvideWeatherViewModel(weatherPage);
        }
    }
}
