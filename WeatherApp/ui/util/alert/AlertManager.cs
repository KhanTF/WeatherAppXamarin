using System;
using WeatherApp.ui.util.alert;
using Xamarin.Forms;

namespace WeatherApp.ui
{
    public class AlertManager : IAlertManager
    {
        private Page page;
        public AlertManager(Page page)
        {
            this.page = page;
        }

        public void ShowAlert(string title, string message, string cancel)
        {
            page.DisplayAlert(title, message, cancel);
        }
    }
}
