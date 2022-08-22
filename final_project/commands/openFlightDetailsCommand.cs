using final_project.viewModels;
using flightModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace final_project.commands
{
    public class openFlightDetailsCommand : ICommand
    {
        private IVM vm;

        public event Action<flightInfoPartial> openwndFlightDetails;

        public openFlightDetailsCommand(IVM _vm)
        {
            this.vm = _vm;
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
            openwndFlightDetails(parameter as flightInfoPartial);
        }
    }
}
