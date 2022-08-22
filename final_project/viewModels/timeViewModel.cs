using final_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace final_project.viewModels
{
    public class timeViewModel : INotifyPropertyChanged, IVM
    {
        #region properties
        public timeModel timeModel { get; set; }
        private timeWindow window { get; set; }
        bool isAlive { get; set; }
        public timeViewModel(string flightCode, timeWindow timeWindow)
        {
            this.timeModel = new timeModel();
            this.timeModel.setCode(flightCode);
            this.window = timeWindow;
            //set thread
            this.backgroundTread = new BackgroundWorker();
            this.backgroundTread.DoWork += BackgroundTread_DoWork;
            this.backgroundTread.ProgressChanged += BackgroundTread_ProgressChanged;
            this.backgroundTread.WorkerReportsProgress = true;
            this.backgroundTread.RunWorkerCompleted += BackgroundTread_RunWorkerCompleted;

            //start thread that update time every second
            this.isAlive = true;
            this.backgroundTread.RunWorkerAsync();
        }
        #endregion

        #region Thread
        BackgroundWorker backgroundTread { get; set; }

        private void BackgroundTread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ///popup and close window
            this.window.Close();
        }

        private void BackgroundTread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.currentFlight = this.timeModel.currentFlight;
            this.getReminingTime = (this.currentFlight.time.scheduled.t_arrival.TimeOfDay - DateTime.Now.TimeOfDay).ToString();
            if (this.currentFlight.time.scheduled.t_arrival.TimeOfDay ==  new TimeSpan(3,0,0) )
                this.isAlive = false;
        }

        private void BackgroundTread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (this.isAlive)
            {
                this.backgroundTread.ReportProgress(1);
                Thread.Sleep(1000); // Sleep for a second.  
            }
        }

        #endregion

        #region currentFlight
        private flightModel.flightInfo _currentFlight;
        public flightModel.flightInfo currentFlight
        {
            get
            {
                return this._currentFlight;
            }
            set
            {
                this._currentFlight = value;
                OnPropertyChanged();
            }
       
        }
        #endregion

        #region ReminingTime
        private string _getReminingTime;
        public string getReminingTime
        {
            get
            {
                return _getReminingTime;
            }
            set
            {
                this._getReminingTime = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region onPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
