using flightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airTrafficDAL
{
    public interface IDL
    {
        Dictionary<string, List<flightInfoPartial>> GetCurrentFlights();
        flightInfo getSingleFlight(string Id);
        bool saveNewUser(user user);
        user getUser(string _userName, string _password);
        user logInUeser(user user);
        cityWeather GetCityWeather(string cityName);
        bool saveChanges(user _user);
        string getHoliday();

    }
}
