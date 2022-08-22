using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace final_project.commands
{
    public class NavigateHomeCommand : ICommand
    {
        private flightsViewModel VM;
        public NavigateHomeCommand(flightsViewModel flightsViewModel)
        {
            this.VM = flightsViewModel;
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
            this.VM.IsHome = true;
            //set all the rest to not visible
            this.VM.IsSignIn = false;
            this.VM.IsHistory = false;
            this.VM.islogIn = false;
        }
    }
}
