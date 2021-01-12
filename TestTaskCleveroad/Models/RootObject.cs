using System;
using System.Collections.Generic;

namespace TestTaskCleveroad.Models
{
    public class RootObject
    {
        public string dt_txt { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public List<Weather> weather{ get; set; }
    }

    public class RootObjectForecast
    {
        public List<RootObject> list { get; set; }
  
    }

    public class Wind
    {
        public double Speed { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

}
