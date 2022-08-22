using airTrafficBL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class HistoryModel
    {
        IBL iBL;
        DateTime from;
        DateTime to;

        public ObservableCollection<flightModel.flightInfo> flightsHistoryPerUser { get; set; }
        public HistoryModel()
        {
            BLFactory factory = new BLFactory();
            iBL = factory.getTheInstacne(); //get from factory
            this.flightsHistoryPerUser = new ObservableCollection<flightModel.flightInfo>();
            this.from = DateTime.Today;
            this.to = DateTime.Today;

        }    
        public void setDates(DateTime from, DateTime to)
        {
            ObservableCollection<flightModel.flightInfo> newList = new ObservableCollection<flightModel.flightInfo>();
            foreach (var flight in this.flightsHistoryPerUser)
            {
                if(flight.time.scheduled.t_arrival.Date>=from && flight.time.scheduled.t_arrival.Date <= to)
                {
                    newList.Add(flight);
                }
            }
            this.flightsHistoryPerUser = newList;
        }
        
    }
}
