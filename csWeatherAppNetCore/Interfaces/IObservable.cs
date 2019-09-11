using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csWeatherAppNetCore.Helpers;

namespace csWeatherAppNetCore.Interfaces
{
    public interface IObservable
    {
        void NotifyObservers(EventArgs e);
    }
}
