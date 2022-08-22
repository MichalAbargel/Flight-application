using final_project.viewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace final_project.commands
{
    public class closeMessageCommand : ICommand
    {
        private flightsViewModel vm;
        public closeMessageCommand(flightsViewModel flightsViewModel)
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
            Snackbar snackbar = parameter as Snackbar;
            if (snackbar != null)
            {
                snackbar.IsActive = false;
            }
            //this.vm.messageVisibility = false;
        }
    }
}
