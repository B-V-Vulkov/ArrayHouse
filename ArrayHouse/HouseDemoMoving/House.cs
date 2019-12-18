using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HouseDemoMoving
{
    public class House : INotifyPropertyChanged
    {
        private double xPosition;

        private double yPosition;

        public int Number { get; set; }

        public double XPosition 
        {
            get 
            {
                return this.xPosition;
            }
            set 
            {
                this.xPosition = value;
                NotifyPropertyChanged();
            }
        }

        public double YPosition
        {
            get
            {
                return this.yPosition;
            }
            set
            {
                this.yPosition = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
