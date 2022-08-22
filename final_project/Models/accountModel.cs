using airTrafficBL;
using flightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class accountModel
    {
        #region properties
        IBL iBL; //poiter to get data from bl
        public flightModel.user user;
        public string userName
        {
            get
            {
                return this.user.UserName;
            }
            set
            {
                this.user.UserName = value;
            }
        }
        public string password
        {
            get
            {
                return this.user.password;
            }
            set
            {
                this.user.password = value;
            }
        }
        #endregion

        #region constractor
        public accountModel()
        {
            BLFactory factory = new BLFactory();
            iBL = factory.getTheInstacne(); //get from factory
            this.user = new flightModel.user();
            this.user.flightsHistory = new List<flightModel.flightSource>();
        }
        #endregion

        #region checks
        public bool alreadyExist() 
       {
            //check in data if user already exist.
            //return true if user exist.
            if(this.iBL.checkIfUserExist(this.user))
                return true;
            return false;
       }
        #endregion

        #region signIn
        public bool signIn()
        {
            //TODO
            // if saving data sucssfull ->return true
            if(this.iBL.saveNewUser(this.user))
                return true;
            return false;
        }
        #endregion

        #region logIn
        public bool logIn()
        {
            user loginUser = this.iBL.logInUeser(this.user);
            if (loginUser == null)
                return false;
            this.user = loginUser;
            return true;
        }
        #endregion

        #region save
        public void saveChanges(List<flightModel.flightInfo> listToSave)
        {
            
            this.user.flightsHistory = new List<flightSource>();

            foreach (var item in listToSave)
            {
                this.user.flightsHistory.Add(new flightModel.flightSource{ flightCode = item.identification.id });
            }
            this.iBL.saveChanges(this.user);
        }
        #endregion

        #region history
        public List<flightInfo> gethistoryForUser()
        {
            List<flightInfo> flights = new List<flightInfo>();

            foreach (var item in this.user.flightsHistory)
            {
                flights.Add(iBL.GetSingleFlight(item.flightCode));
            }
            return flights;
        }
        #endregion
    }
}
