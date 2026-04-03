using System;
using System.Collections.Generic;
using System.Text;

namespace Observer.Example
{
    public interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
        string GetName();
    }

}
