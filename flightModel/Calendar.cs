using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightModel
{
    public class Calendar
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

            public string title { get; set; }
            public DateTime date { get; set; }
            public Location location { get; set; }
            public Range range { get; set; }
            public List<Item> items { get; set; }


        public class Item
        {
            public string title { get; set; }
            public string date { get; set; }
            public string hdate { get; set; }
            public string category { get; set; }
            public string subcat { get; set; }
            public string hebrew { get; set; }
            public string link { get; set; }
            public string memo { get; set; }

        }

        public class Location
        {
            public string geo { get; set; }
        }

        public class Range
        {
            public string start { get; set; }
            public string end { get; set; }
        }

        

    }
}
