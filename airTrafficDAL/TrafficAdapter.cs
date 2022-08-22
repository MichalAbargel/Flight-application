using System;
using System.Activities;
using System.Collections.Generic;
using System.Device.Location;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using flightModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sqlServer;

namespace airTrafficDAL
{
    public class TrafficAdapter : IDL
    {
        public TrafficAdapter()
        {
        }



        #region API
        private const string allURL = @"https://data-cloud.flightradar24.com/zones/fcgi/feed.js?faa=1&bounds=41.13,29.993,25.002,36.383&satellite=1&mlat=1&flarm=1&adsb=1&gnd=1&air=1&vehicles=1&estimated=1&maxage=14400&gliders=1&selected=2d1e1f33&ems=1&stats=1";
        private const string flightURL = @"https://data-live.flightradar24.com/clickhandler/?version=1.5&flight=";
        private const string weather = @"https://api.openweathermap.org/data/2.5/weather?q=";
        private const string APIWeather = @"&mode=json&units=metric&appid=###API_key###";
        private const string calendarAPI = @"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&year=now&i=on&month=x&geo=geoname&geonameid=3448439&leyning=off&geo=Jerusalem";
        private const string holidaysAPI = @"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&start=";
        private const string holidaysAPIend = @"&end=";
       
        #endregion

        #region calander
        public string getHoliday()
        {
            Calendar calendar = null;
            string start = DateTime.Today.ToString("yyyy-MM-dd").Replace('/', '-');
            string end = DateTime.Today.AddDays(50).ToString("yyyy-MM-dd").Replace('/', '-');
            string url = holidaysAPI + start + holidaysAPIend + end;
            var json = RequestDataSync(url);
            calendar = JsonConvert.DeserializeObject<Calendar>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            if (calendar.items.Count > 0)
            {
                calendar.items.RemoveAll(i => i.subcat == "fast");
                return "A week before a holiday: " + calendar.items.Last().title;
            }
            return "";
        }
        #endregion


        #region requestData
        private async Task<string> RequestData(string uri)
        {
            using (var webClient = new System.Net.WebClient())
            {
                return await webClient.DownloadStringTaskAsync(allURL).ConfigureAwait(false);
            }
        }
        private string RequestDataSync(string uri) 
        {
            using (var webClient = new System.Net.WebClient())
            {
                return webClient.DownloadString(uri);
            }
        }
        #endregion

        #region flights
        public Dictionary<string, List<flightInfoPartial>> GetCurrentFlights()
        {
            JObject AllFlightsData = null;
            //IList<string> keys = null;
           // IList<Object> values = null;

            Dictionary<string, List<flightInfoPartial>> flightsDictionary = new Dictionary<string, List<flightInfoPartial>>();

            List<flightInfoPartial> Incoming = new List<flightInfoPartial>();
            List<flightInfoPartial> Outgoing = new List<flightInfoPartial>();

            using(var webClient = new System.Net.WebClient())
            {
                //async
                //var json = RequestData(allURL); //download  data from url
                //AllFlightsData = JObject.Parse(json.Result);

                //sync
                var json = RequestDataSync(allURL);
                AllFlightsData = JObject.Parse(json);
                try
                {
                    foreach(var item in AllFlightsData)
                    {
                        var key = item.Key;
                        if (key == "full_count" || key == "version")
                            continue;
                        if (item.Value[11].ToString() == "TLV")
                            Outgoing.Add(new flightInfoPartial { 
                                Id = -1, Source = item.Value[11].ToString(), 
                                Destination = item.Value[12].ToString(), SourceId = key, 
                                Long = Convert.ToDouble(item.Value[2]), Lat = Convert.ToDouble(item.Value[1]), 
                                DateAndTime = EpochToDateTime.GetDateTimeFromeEpoch(Convert.ToDouble(item.Value[10])), 
                                flightCode = item.Value[13].ToString(), 
                                location = new GeoCoordinate(Convert.ToDouble(item.Value[2]), 
                                Convert.ToDouble(item.Value[1]))
                            });
                        else if (item.Value[12].ToString() == "TLV")
                            Incoming.Add(new flightInfoPartial { 
                                Id = -1, Source = item.Value[11].ToString(), 
                                Destination = item.Value[12].ToString(), 
                                SourceId = key, 
                                Long = Convert.ToDouble(item.Value[2]), 
                                Lat = Convert.ToDouble(item.Value[1]), 
                                DateAndTime = EpochToDateTime.GetDateTimeFromeEpoch(Convert.ToDouble(item.Value[10])), 
                                flightCode = item.Value[13].ToString(), 
                                location = new GeoCoordinate(Convert.ToDouble(item.Value[2]), 
                                Convert.ToDouble(item.Value[1]))
                            });
                    }
                }
                catch(Exception e)
                {
                    Debug.Print(e.Message);
                }

                flightsDictionary.Add("Incoming", Incoming);
                flightsDictionary.Add("Outgoing", Outgoing);
            }
            return flightsDictionary;
        }

        public flightInfo getSingleFlight(string flightCode)
        {
            flightInfo flightData = null;
            try
            {
                string url = flightURL + flightCode;
                var json = RequestDataSync(url); //download  data from url
                flightData = JsonConvert.DeserializeObject<flightInfo>(json,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                
            }catch(Exception e)
            {
                if (flightData == null)
                    flightData = null;
                Debug.Print(e.Message);
            }
                return flightData;
        }

        #endregion

        #region users
        public bool saveNewUser(user user)
        {
            ContosoPetsContext context = new ContosoPetsContext();

            try
            {
                context.users.Add(user);
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.users ON");
                context.SaveChanges();
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.users OFF");
                return true;
            }
            catch(Exception e)
            {
                //in case of Errors:
                Debug.WriteLine(e.Message);
                return false;
            }

        }

        public user getUser(string _userName, string _password)
        {
            ContosoPetsContext context = new ContosoPetsContext();
            try
            {
                var myuser = context.users
                    .Where(user => user.password == _password
                                && user.UserName == _userName).
                                Include(user=>user.flightsHistory).FirstOrDefault();


                return myuser;
            }
            catch
            {
                //in case of Errors:
                return null;
            }
        }

        public bool saveChanges(user _user)
        {
            ContosoPetsContext context = new ContosoPetsContext();
            var myuser = context.users
                    .Where(user => user.password == _user.password
                                && user.UserName == _user.UserName).
                                FirstOrDefault();
            try
            {
                context.users.Attach(myuser).Collection(x=>x.flightsHistory).CurrentValue=_user.flightsHistory;
                context.SaveChanges();
                //myuser.flightsHistory = _user.flightsHistory;
                //context.Add(myuser);
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.users ON");
                //context.SaveChanges();
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.users OFF");
                //return true;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }

        public user logInUeser(user _user)
        {
            user myuser = this.getUser(_user.UserName, _user.password);
           
            if (myuser != null)
                return myuser;
            else
                return null;
        }
        #endregion

        #region weather
        public cityWeather GetCityWeather(string cityName)
        {
            cityWeather cityWeather = null;
            try
            {
                string url = weather + cityName + APIWeather;
                var json = RequestDataSync(url); //download  data from url
                cityWeather = JsonConvert.DeserializeObject<cityWeather>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }            return cityWeather;
        }
        #endregion


    }
}
