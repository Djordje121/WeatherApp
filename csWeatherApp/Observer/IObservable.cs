using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csWeatherApp.Helpers;

namespace csWeatherApp.Observer
{
    public interface IObservable
    {
        void NotifyObservers(EventArgs e);
    }
}
