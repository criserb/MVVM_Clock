using MVVM_Clock.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVM_Clock.ViewModel
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "Clock App";

        private Clock _clock;

        public Clock Clock
        {
            get { return _clock; }
            set { _clock = value; NotifyOnPropertyChanged("Clock"); }
        }

        public ClockViewModel()
        {
            Clock = new Clock();
            Clock.Timer.Tick += new EventHandler(this.Tick);
        }

        private void Tick(object sender, EventArgs e)
        {
            Clock++;
        }

        private void NotifyOnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
