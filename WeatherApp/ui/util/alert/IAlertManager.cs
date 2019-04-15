using System;
namespace WeatherApp.ui.util.alert
{
    public interface IAlertManager
    {
        void ShowAlert(string title, string message, string cancel);
    }
}
