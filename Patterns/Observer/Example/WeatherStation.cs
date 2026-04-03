using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Example
{
    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers;
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public WeatherStation()
        {
            _observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"📱 {observer.GetName()} подписался на уведомления");
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"📱 {observer.GetName()} отписался от уведомлений");
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temperature, _humidity, _pressure);
            }
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            Console.WriteLine($"\n🌡️ НОВЫЕ ДАННЫЕ: Температура: {temperature}°C, Влажность: {humidity}%, Давление: {pressure} мм рт.ст.");

            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;

            NotifyObservers();
        }
    }
}
