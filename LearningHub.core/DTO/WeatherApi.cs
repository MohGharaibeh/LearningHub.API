using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.DTO
{
    public class Main
    {
        public decimal temp { get; set; }
        public decimal humidity { get; set; }

    }
    public class WeatherApi
    {
        public Main main { get; set; }
        public decimal timezone { get; set; }
        public string name { get; set; }
    }
}
