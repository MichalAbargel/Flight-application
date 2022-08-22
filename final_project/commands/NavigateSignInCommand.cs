using final_project.userControls;
using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace final_project.commands
{
    public class NavigateSignInCommand : ICommand
    {
        private flightsViewModel VM;
        public NavigateSignInCommand(flightsViewModel _VM)
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
            this.VM.IsSignIn = true; //set singIn popup to visible
            //set all the rest to not visible
            this.VM.IsHistory = false;
            this.VM.islogIn = false;
            this.VM.IsHome = false;

        }
    }
}
