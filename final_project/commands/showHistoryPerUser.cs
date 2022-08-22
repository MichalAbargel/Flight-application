using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace final_project.commands
{
    public class showHistoryPerUser : ICommand
    {
        private flightsViewModel VM;

        public showHistoryPerUser(flightsViewModel flightsViewModel)
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
            this.VM.startSearch = true;
            this.VM.showHistory();
        }
    }
}
