using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightModel
{
    public class user
    {
        public int UserId { get; set; }
        public string password { get; set; }
        public string UserName { get; set; }

        public ICollection<flightSource> flightsHistory { get; set; }
       
    }
}
