using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Unity;
using WeatherApp.ui.util.state;
using WeatherApp.ui.view;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        private static readonly string KEY_STACK = "KEY_STACK";

        public App()
        {
            InitializeComponent();

            if (Properties.ContainsKey(KEY_STACK))
            {
                MainPage = new NavigationPage();
            }
            else
            {
                MainPage = new NavigationPage(new CityListPage());
            }
        }

        protected override void OnStart()
        {
            if (Properties.ContainsKey(KEY_STACK))
            {
                string[] stackTypes = JsonConvert.DeserializeObject<string[]>(Application.Current.Properties[KEY_STACK] as string);
                foreach (string typePath in stackTypes)
                {
                    Type type = Type.GetType(typePath);
                    Page page = (Page)Activator.CreateInstance(type);
                    if (page is IMemento state)
                    {
                        if (Application.Current.Properties.ContainsKey(state.GetId()))
                            state.SetState(JsonConvert.DeserializeObject<IDictionary<string, object>>(Application.Current.Properties[state.GetId()] as string));
                        MainPage.Navigation.PushAsync(page);
                    }
                }
            }
        }

        protected override void OnSleep()
        {
            IReadOnlyList<Page> stack = MainPage.Navigation.NavigationStack;
            string[] stackTypes = new string[stack.Count];
            int i = 0;
            foreach (Page page in stack)
            {
                if (page is IMemento state)
                {
                    Application.Current.Properties[state.GetId()] = JsonConvert.SerializeObject(state.GetState());
                }
                string typeName = page.GetType().AssemblyQualifiedName;
                stackTypes[i++] = typeName;
            }
            Application.Current.Properties[KEY_STACK] = JsonConvert.SerializeObject(stackTypes);
        }

        protected override void OnResume()
        {
        }

    }
}
