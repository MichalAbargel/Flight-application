using airTrafficBL;
using flightModel;
using System.Collections.Generic;

namespace final_project.Models
{
    public class flightsModel
    {
        IBL iBL; //poiter to get data from bl

        #region allFlighs
        public List<flightInfoPartial> IncomingFlights { get { return this.iBL.GetCurrentFlights()["Incoming"]; } }
        public List<flightInfoPartial> OutgoingFlights { get { return this.iBL.GetCurrentFlights()["Outgoing"]; } }
        #endregion

        #region singleFlight
        public flightInfo singleFlightInfo { get; set; }

        #endregion

        #region propertiesPerFlight
        public string sourseFlight { get { return this.singleFlightInfo.airport.origin.name; } }
        public string destinationFlight { get { return this.singleFlightInfo.airport.destination.name; } }

        #endregion

        #region propertiesPerHoliday
        public string getholiday
        {
            get
            {
                return this.iBL.getHoliday();
            }
        }
        #endregion

        #region private
        private string code;
        #endregion

        #region constractor
        public flightsModel()
        {
            BLFactory factory = new BLFactory();
            iBL = factory.getTheInstacne(); //get from factory


        }
        #endregion

        #region setDataToModel
        public void setCodeFlight(string _code)
        {
            this.code = _code;
            this.singleFlightInfo = iBL.GetSingleFlight(code);
        }
        #endregion


    }
}
