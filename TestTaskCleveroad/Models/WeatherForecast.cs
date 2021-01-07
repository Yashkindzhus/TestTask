using System;
using System.Collections.Generic;

namespace TestTaskCleveroad.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int Temp { get; set; }
        public Wind wind { get; set; }
        public List<Weather> weather{ get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
    }

    public class Weather
    {

        public string Description { get; set; }
    }
}
