using Observer.Example.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Example
{
    class Example
    {
        static void Main()
        {
            var weatherStation = new WeatherStation();

            var currentDisplay = new CurrentConditionsDisplay("Дисплей в холле");
            var statisticsDisplay = new StatisticsDisplay("Дисплей статистики");
            var forecastDisplay = new ForecastDisplay("Дисплей прогнозов");
            var alertDisplay = new AlertDisplay("Дисплей безопасности");

            weatherStation.RegisterObserver(currentDisplay);
            weatherStation.RegisterObserver(statisticsDisplay);
            weatherStation.RegisterObserver(forecastDisplay);
            weatherStation.RegisterObserver(alertDisplay);


            weatherStation.SetMeasurements(22.5f, 65, 1013);

            weatherStation.SetMeasurements(23.0f, 66, 1012);

            weatherStation.SetMeasurements(28.5f, 70, 1008);

            weatherStation.SetMeasurements(38.0f, 85, 1005);

            weatherStation.RemoveObserver(statisticsDisplay);

            weatherStation.SetMeasurements(25.0f, 60, 1015);


            var newDisplay = new CurrentConditionsDisplay("Новый дисплей на ресепшене");
            weatherStation.RegisterObserver(newDisplay);

            weatherStation.SetMeasurements(24.0f, 55, 1014);
        }
    }
}
