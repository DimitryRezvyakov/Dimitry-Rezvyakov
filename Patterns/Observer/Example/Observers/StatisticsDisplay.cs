using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Example.Observers
{
    public class StatisticsDisplay : IObserver
    {
        private List<float> _temperatures;
        private string _name;

        public StatisticsDisplay(string name)
        {
            _name = name;
            _temperatures = new List<float>();
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            _temperatures.Add(temperature);
            Display();
        }

        public void Display()
        {
            float min = _temperatures.Min();
            float max = _temperatures.Max();
            float avg = _temperatures.Average();

            Console.WriteLine($"📊 [{_name}] Статистика температуры: мин {min}°C, макс {max}°C, средняя {avg:F1}°C");
        }

        public string GetName() => _name;
    }
}
