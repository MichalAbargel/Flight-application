using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace final_project.commands
{
    public class openHistoryCommand : ICommand
    {
        flightsViewModel VM;
        public openHistoryCommand(flightsViewModel _VM)
        {
            this.VM = _VM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (this.VM.usesrIslogin)
            {
                this.VM.flightsHistoryPerUser = new ObservableCollection<flightModel.flightInfo>(this.VM.accountModel.gethistoryForUser());
            }
            else
            {
                this.VM.flightsHistoryPerUser = new ObservableCollection<flightModel.flightInfo>();
            }
            this.VM.IsHistory = true;
            //set all the rest to not visible
            this.VM.IsSignIn = false;
            this.VM.isFlightDetailsUC = false;
            this.VM.islogIn = false;
            this.VM.IsHome = false;
           
            
        }
    }
}
