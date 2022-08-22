using airTrafficBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class timeModel
    {
        IBL iBL;
        string code;
        public flightModel.flightInfo currentFlight { 
            get 
            {
                return this.iBL.GetSingleFlight(this.code);
            }
        }
        public timeModel()
        {
            BLFactory factory = new BLFactory();
            iBL = factory.getTheInstacne(); //get from factory
        }
        public void setCode(string code)
        {
            this.code = code;
        }
    }
}
