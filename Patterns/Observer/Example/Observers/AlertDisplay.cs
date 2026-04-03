using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Example.Observers
{
    public class AlertDisplay : IObserver
    {
        private string _name;

        public AlertDisplay(string name)
        {
            _name = name;
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            if (temperature > 35)
            {
                Console.WriteLine($"⚠️ [{_name}] ТРЕВОГА! Экстремальная жара: {temperature}°C!");
            }
            else if (temperature < -10)
            {
                Console.WriteLine($"⚠️ [{_name}] ТРЕВОГА! Экстремальный холод: {temperature}°C!");
            }
            else if (humidity > 90)
            {
                Console.WriteLine($"⚠️ [{_name}] ПРЕДУПРЕЖДЕНИЕ! Очень высокая влажность: {humidity}%");
            }
            else
            {
                Console.WriteLine($"✅ [{_name}] Всё в норме: {temperature}°C, влажность {humidity}%");
            }
        }

        public string GetName() => _name;
    }
}
