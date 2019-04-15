using System;
using System.Collections.Generic;
using WeatherApp.di;
using Xamarin.Forms;

namespace WeatherApp.ui.view
{
    public class MainPage : NavigationPage
    {
        public MainPage() : base()
        {
            Injector.GetInstance().Inject(this); 
        }
        public MainPage(Page page) : base(page)
        {
            Injector.GetInstance().Inject(this);
        }
    }
}

