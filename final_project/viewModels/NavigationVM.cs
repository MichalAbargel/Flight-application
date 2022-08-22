using final_project.commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace final_project.viewModels
{
    public class NavigationVM : INotifyPropertyChanged, IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public flightsViewModel VM;

        #region properties
        public bool navIsHome { get; set; }
        public bool navIsSignIn { get; set; }
        public bool navIsLoggedIn { get; set; }
        public bool navIsHistory { get; set; }
        public NavigateSignInCommand navigateSignInCommand { get; set; }

        public NavigateLoginCommand navigateLogInCommand { get; set; }
        public openHistoryCommand openHistoryCommand { get; set; }
        public NavigateHomeCommand NavigateHomeCommand { get; set; }
        #endregion

        #region constractor
        public NavigationVM(flightsViewModel flightsViewModel)
        {
            this.VM = flightsViewModel;
            navigateSignInCommand = new NavigateSignInCommand(VM);
            navigateLogInCommand = new NavigateLoginCommand(VM);
            openHistoryCommand = new openHistoryCommand(VM);
            NavigateHomeCommand = new NavigateHomeCommand(VM);
            //set all unvisible
            this.navIsHistory = true;
            this.navIsLoggedIn = true;
            this.navIsSignIn = true;
            this.navIsHome = true;
        }
        #endregion 

    }
}
