using System;
using System.Collections;
using System.Collections.Generic;

namespace WeatherApp.ui.util.state
{
    public interface IMemento
    {
        string GetId();
        IDictionary<string, object> GetState();
        void SetState(IDictionary<string, object> state); 
    }
}
