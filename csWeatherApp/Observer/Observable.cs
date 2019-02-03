using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace csWeatherApp
{
    [DataContract]
    class Observable
    {
        private List<IObserver> _observers;

        private bool _stateChanged;

        public string name { get; set; }

        public Observable()
        {
            _observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(EventArgs e)
        {
            if (_stateChanged)
            {
                foreach (IObserver observer in _observers)
                {
                    observer.Update(this, e);
                }
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
