using airTrafficDAL;
using flightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airTrafficBL
{
    public class BLimpl: IBL
    {
        IDL itsIDL;

        public BLimpl() {
            itsIDL = new TrafficAdapter();
        }

        public bool checkIfUserExist(user user)
        {
            if (this.itsIDL.getUser(user.UserName, user.password) == null)
                return false;
            return true;
        }

        public cityWeather GetCityWeather(string cityName)
        {
            return this.itsIDL.GetCityWeather(cityName);
        }

        public Dictionary<string, List<flightInfoPartial>> GetCurrentFlights()
       {
            return itsIDL.GetCurrentFlights();
       }

        public string getHoliday()
        {
            return itsIDL.getHoliday();
        }

        public flightInfo GetSingleFlight(string Id)
        {
            return itsIDL.getSingleFlight(Id);
        }

        public user logInUeser(user user)
        {
            return this.itsIDL.logInUeser(user);
        }

        public bool saveChanges(user _user)
        {
            return this.itsIDL.saveChanges(_user);
        }

        public bool saveNewUser(user user)
        {
           return this.itsIDL.saveNewUser(user);
        }
    }
}
