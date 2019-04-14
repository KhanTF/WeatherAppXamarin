using System;
namespace WeatherApp.ui.viewmodel
{
    public class ViewModelProvider
    {
        public ViewModelProvider()
        {
        }

        public CityListViewModel ProvideCityListViewModel()
        {
            return new CityListViewModel();
        }

    }
}
