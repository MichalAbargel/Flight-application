using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightModel
{
    public class flightInfoPartial
    {
        public int Id { get; set; }
        public string SourceId { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public GeoCoordinate location { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string flightCode { get; set; }
    }

  
   
}




