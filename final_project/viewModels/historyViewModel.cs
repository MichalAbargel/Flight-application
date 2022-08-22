using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace final_project.viewModels
{
    public class historyViewModel : INotifyPropertyChanged, IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public historyViewModel()
        {

        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
