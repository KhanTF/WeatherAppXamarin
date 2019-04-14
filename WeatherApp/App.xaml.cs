using System;
using Unity;
using WeatherApp.ui.view;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {

        private UnityContainer unityContainer = new UnityContainer();

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage(); 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
