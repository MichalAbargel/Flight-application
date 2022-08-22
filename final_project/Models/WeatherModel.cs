using airTrafficBL;
using flightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class WeatherModel
    {
        IBL iBL;
        public cityWeather originWeather { get; set; }
        public cityWeather destinationWeather { get; set; }

        public WeatherModel()
        {
            BLFactory factory = new BLFactory();
            iBL = factory.getTheInstacne(); //get from factory
        }
        public void setOriginCode(string code)
        {
            this.originWeather = iBL.GetCityWeather(code);
        }

        public void setDestinationCode(string originName, string destinationName)
        {
            this.originWeather = iBL.GetCityWeather(originName);
            this.destinationWeather = iBL.GetCityWeather(destinationName);
        }
    }
}
