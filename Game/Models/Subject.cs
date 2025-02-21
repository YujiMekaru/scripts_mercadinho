using Assets.Scripts.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Models
{
    public abstract class Subject
    {
        private List<ICustomObserver> _observers = new List<ICustomObserver>();
        
        public void AddObserver(ICustomObserver observer) // Attach
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ICustomObserver observer) // Detach
        {
            _observers.Remove(observer);
        }

        protected void NotifyObservers() // Notify
        {
            _observers.ForEach((_observers) =>
            {
                _observers.OnNotify();
            });
        }
    }
}
