using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csWeatherAppNetCore.Interfaces
{
    public interface IObserver
    {
        void Update(object sender, EventArgs args);
    }
}
