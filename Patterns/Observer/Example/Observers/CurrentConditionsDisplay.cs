using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Example.Observers
{
    public class CurrentConditionsDisplay : IObserver
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;
        private string _name;

        public CurrentConditionsDisplay(string name)
        {
            _name = name;
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"🖥️ [{_name}] Текущая погода: {_temperature}°C, влажность {_humidity}%, давление {_pressure} мм рт.ст.");
        }

        public string GetName() => _name;
    }
}
