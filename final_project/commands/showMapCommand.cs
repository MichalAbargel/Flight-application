using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace final_project.commands
{
    public class showMapCommand
    {
        private IVM VM;

        public showMapCommand(IVM _VM)
        {
            this.VM = _VM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<ObservableCollection<flightModel.flightInfoPartial>> addFlightsToMap; 


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (this.addFlightsToMap != null)
                addFlightsToMap(parameter as ObservableCollection<flightModel.flightInfoPartial>);
        }
    }
}

