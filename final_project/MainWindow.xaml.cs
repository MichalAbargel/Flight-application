using airTrafficBL;
using final_project.viewModels;
using flightModel;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace final_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        flightsViewModel flightsVM;
        IBL ibl;
        public MainWindow()
        {
            InitializeComponent();
            BLFactory factory = new BLFactory();
            ibl = factory.getTheInstacne(); //get from factory
            this.flightsVM = new flightsViewModel(this);
            this.DataContext = this.flightsVM;
        }

       


    }
}
