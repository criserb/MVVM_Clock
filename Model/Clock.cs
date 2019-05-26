using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVM_Clock.Model
{
    public class Clock : INotifyPropertyChanged
    {
        private int _hour = DateTime.Now.Hour;

        public int Hour
        {
            get { return _hour; }
            set { _hour = value; OnPropertyChanged("Second"); }
        }

        private int _minute = DateTime.Now.Minute;

        public int Minute
        {
            get { return _minute; }
            set { _minute = value; OnPropertyChanged("Second"); }
        }

        private int _second = DateTime.Now.Second;

        public int Second
        {
            get { return _second; }
            set { _second = value; OnPropertyChanged("Second"); }
        }

        private Timer _timer;

        public Timer Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }

        public static Clock operator ++(Clock c)
        {
            if (c.Second++ == 59)
            {
                c.Second = 0;
                if (c.Minute++ == 59)
                {
                    c.Minute = 0;
                    c.Hour++;
                    if (c.Hour == 24)
                    {
                        c.Hour = 0;
                    }
                }
            }
            return c;
        }

        public Clock()
        {
            Timer = new Timer
            {
                Interval = 1000,
                Enabled = true
            };
            Timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
