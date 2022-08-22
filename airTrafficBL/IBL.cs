using flightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airTrafficBL
{
    public interface IBL
    {
        Dictionary<string, List<flightInfoPartial>> GetCurrentFlights();
        flightInfo GetSingleFlight(string Id);

        bool saveNewUser(user user);
        user logInUeser(user user);
        cityWeather GetCityWeather(string cityName);
        bool checkIfUserExist(user user);
        bool saveChanges(user _user);

        string getHoliday();

    }
}
