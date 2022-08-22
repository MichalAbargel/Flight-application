using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace final_project.commands
{
    public class openTimeWIndowCommand : ICommand
    {
        private flightsViewModel vm;
        public openTimeWIndowCommand(flightsViewModel flightsViewModel)
        {
            this.vm = flightsViewModel;
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
            timeWindow timeWindow = new timeWindow();
            timeWindow.DataContext = new timeViewModel(vm.singleFlight.identification.id, timeWindow);
            timeWindow.Show();
        }
    }
}
