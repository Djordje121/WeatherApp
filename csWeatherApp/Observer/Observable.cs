using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace csWeatherApp
{
    [DataContract]
    public abstract class Observable
    {
        public event EventHandler NotifyObserversEventHandler;
        private bool _stateChanged;

        public string name { get; set; }

        public void NotifyObservers(EventArgs args)
        {
            if (_stateChanged && NotifyObserversEventHandler != null)
            {
                NotifyObserversEventHandler.Invoke(this, args);
                ClearStateChanged();
            }
        }

        public void NotifyObservers()
        {
            NotifyObservers(null);
        }

        public void SetStateChanged()
        {
            _stateChanged = true;
        }

        public void ClearStateChanged()
        {
            _stateChanged = false;
        }
    }
}
