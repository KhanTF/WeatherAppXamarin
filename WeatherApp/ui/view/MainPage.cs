using System;

using Xamarin.Forms;

namespace WeatherApp.ui.view
{
    public class MainPage : NavigationPage
    {
        public MainPage()
        { 
            PushAsync(new CityListPage()); 
        }
    }
}

