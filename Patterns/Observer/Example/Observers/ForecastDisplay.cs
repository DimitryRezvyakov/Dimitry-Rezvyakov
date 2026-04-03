using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Example.Observers
{
    public class ForecastDisplay : IObserver
    {
        private float _lastPressure;
        private float _currentPressure;
        private string _name;

        public ForecastDisplay(string name)
        {
            _name = name;
            _lastPressure = 0;
            _currentPressure = 0;
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            _lastPressure = _currentPressure;
            _currentPressure = pressure;
            Display();
        }

        public void Display()
        {
            string forecast;

            if (_currentPressure > _lastPressure)
            {
                forecast = "🌞 Ожидается улучшение погоды, будет тепло и солнечно!";
            }
            else if (_currentPressure < _lastPressure)
            {
                forecast = "🌧️ Ожидается ухудшение погоды, возможны осадки.";
            }
            else
            {
                forecast = "☁️ Погода без изменений.";
            }

            Console.WriteLine($"🔮 [{_name}] Прогноз: {forecast}");
        }

        public string GetName() => _name;
    }
}
